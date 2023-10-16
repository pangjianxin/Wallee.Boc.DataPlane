using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries;


/// <summary>
/// 机构层级表
/// </summary>
public class OrgUnitHierarchyAppService : CrudAppService<OrgUnitHierarchy, OrgUnitHierarchyDto, Guid, OrgUnitHierarchyGetListInput, CreateOrgUnitHierarchyDto, UpdateOrgUnitHierarchyDto>,
    IOrgUnitHierarchyAppService
{


    public OrgUnitHierarchyAppService(IOrgUnitHierarchyRepository repository) : base(repository)
    {

    }

    public async Task<List<OrgUnitHierarchyDto>> GetAllAsync()
    {
        var list = await Repository.GetListAsync();

        return await MapToGetListOutputDtosAsync(list);
    }

    public override async Task<OrgUnitHierarchyDto> CreateAsync(CreateOrgUnitHierarchyDto input)
    {
        if (await Repository.AnyAsync(it => it.OrgIdentity == input.OrgIdentity))
        {
            throw new UserFriendlyException("该机构号已存在,请检查");
        }

        var entity = new OrgUnitHierarchy(GuidGenerator.Create(), input.ParentId, input.OrgIdentity, input.Name);
        await Repository.InsertAsync(entity);

        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<OrgUnitHierarchyDto> UpdateAsync(Guid id, UpdateOrgUnitHierarchyDto input)
    {
        OrgUnitHierarchy entity = await Repository.GetAsync(id);

        if (entity.OrgIdentity != input.OrgIdentity)
        {
            if (await Repository.AnyAsync(it => it.OrgIdentity == input.OrgIdentity))
            {
                throw new UserFriendlyException("该机构号已存在,请检查");
            }
        }
        entity.ConcurrencyStamp = input.ConcurrencyStamp;
        entity.UpdateInfo(input.Name, input.OrgIdentity);
        await Repository.UpdateAsync(entity);
        return await MapToGetOutputDtoAsync(entity);
    }

    public async Task<OrgUnitHierarchyDto> MoveAsync(Guid id, MoveOrgUnitHierarchyDto input)
    {
        OrgUnitHierarchy org = await Repository.GetAsync(id);

        if (org.ParentId == input.ParentId)
        {
            return await MapToGetOutputDtoAsync(org);
        }

        if (await Repository.AnyAsync(it => it.ParentId == org.Id))
        {
            throw new UserFriendlyException("该机构拥有子机构，不能移动");
        }

        org.Move(input.ParentId);

        await Repository.UpdateAsync(org);

        return await MapToGetOutputDtoAsync(org);
    }

    protected override async Task<IQueryable<OrgUnitHierarchy>> CreateFilteredQueryAsync(OrgUnitHierarchyGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
