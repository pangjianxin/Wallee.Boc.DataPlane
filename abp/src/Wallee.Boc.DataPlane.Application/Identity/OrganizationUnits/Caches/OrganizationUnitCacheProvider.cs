using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches
{
    public class OrganizationUnitCacheProvider : IOrganizationUnitCacheProvider, ITransientDependency
    {
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly IDistributedCache<OrganizationUnitCache> _organizationUnitCache;
        private readonly IObjectMapper _objectMapper;
        private readonly IAuthorizationService _authorizationService;
        private static string CACHE_NAME = "organization-unit-cache";
        public OrganizationUnitCacheProvider(
            IOrganizationUnitRepository organizationUnitRepository,
            IDistributedCache<OrganizationUnitCache> organizationUnitCache,
            IObjectMapper objectMapper,
            IAuthorizationService authorizationService)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _organizationUnitCache = organizationUnitCache;
            _objectMapper = objectMapper;
            _authorizationService = authorizationService;
        }
        public async Task<OrganizationUnitCache> GetOrAddOrganizationUnitAsync()
        {
            return (await _organizationUnitCache.GetOrAddAsync(
                 CACHE_NAME,
                 GetOrganizationUnitsFromDatabaseAsync,
                () => new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(6)
                }))!;


        }

        public async Task RefreshAsync()
        {
            await _organizationUnitCache.RemoveAsync(CACHE_NAME);
        }

        public async Task<List<OrganizationUnitDto>> GetVisibleOrganizationUnitsAsync(string? orgCode, bool containsParents = false)
        {
            var organizationUnitCache = await GetOrAddOrganizationUnitAsync();

            if (await _authorizationService.IsGrantedAsync(DataPlanePermissions.OrganizationUnits.Default))
            {
                return organizationUnitCache.Items;
            }

            if (orgCode == default)
            {
                throw new UserFriendlyException("该用户没有机构信息,请联系管理员添加");
            }

            var org = organizationUnitCache.Items.First(it => it.Code == orgCode);

            var visibleList = organizationUnitCache.Items.WhereIf(orgCode != default,
                it => it.Code!.StartsWith(orgCode!)).ToList();

            if (containsParents)
            {
                FindAllParents(org, organizationUnitCache.Items, visibleList);
            }

            return visibleList;

            void FindAllParents(OrganizationUnitDto current, IEnumerable<OrganizationUnitDto> list, List<OrganizationUnitDto> parents)
            {
                if (current.ParentId.HasValue)
                {
                    var parent = list.First(it => it.Id == current.ParentId);
                    parents.Add(parent);
                    FindAllParents(parent, list, parents);
                }
            }
        }

        private async Task<OrganizationUnitCache> GetOrganizationUnitsFromDatabaseAsync()
        {
            var list = await _organizationUnitRepository.GetListAsync();

            return new OrganizationUnitCache
            {
                Items = _objectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(list)
            };
        }
    }
}
