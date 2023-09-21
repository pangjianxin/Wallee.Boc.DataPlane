using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Wallee.Boc.DataPlane.Dashboard.Dtos;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public class DashboardAppService : DataPlaneAppService, IDashboardAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IDistributedCache<ConvertedCusOrgUnitSummary> _convertedCusOrgUnitSummaryCache;
        private readonly IDistributedCache<ConvertedCusOrgUnitDetail> _convertedCusOrgUnitDetailCache;
        private readonly IConvertedCusOrgUnitRepository _convertedCusOrgUnitRepository;
        private readonly IOrganizationUnitCoordinateRepository _organizationUnitCoordinateRepository;
        private readonly IOptions<ConvertedCusOrgUnitCoefficientOptions> _coefficientOptions;

        public DashboardAppService(
            IBackgroundJobManager backgroundJobManager,
            IDistributedCache<ConvertedCusOrgUnitSummary> convertedCusOrgUnitSummaryCache,
            IDistributedCache<ConvertedCusOrgUnitDetail> convertedCusOrgUnitDetailCache,
            IConvertedCusOrgUnitRepository convertedCusOrgUnitRepository,
            IOrganizationUnitCoordinateRepository organizationUnitCoordinateRepository,
            IOptions<ConvertedCusOrgUnitCoefficientOptions> coefficientOptions)
        {
            _backgroundJobManager = backgroundJobManager;
            _convertedCusOrgUnitSummaryCache = convertedCusOrgUnitSummaryCache;
            _convertedCusOrgUnitDetailCache = convertedCusOrgUnitDetailCache;
            _convertedCusOrgUnitRepository = convertedCusOrgUnitRepository;
            _organizationUnitCoordinateRepository = organizationUnitCoordinateRepository;
            _coefficientOptions = coefficientOptions;
        }

        public async Task<ConvertedCusOrgUnitDetail?> GetConvertedCusOrgUnitDetailsAsync(GetConvertedCusOrgUnitDetailsDto input)
        {
            await _coefficientOptions.SetAsync();

            var coefficient = _coefficientOptions.Value;

            var currentDataDate = input.DataDate ?? await _convertedCusOrgUnitRepository.GetCurrentDataDate();

            var cacheName = $"{currentDataDate:yyyyMMdd}-{input.RegionCode ?? "AllRegion"}-{nameof(ConvertedCusOrgUnitDetail)}";

            return await _convertedCusOrgUnitDetailCache.GetOrAddAsync(
                cacheName,
                GetDetailsFromDataBaseAsync,
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = Clock.Now.AddHours(20)
                });

            async Task<ConvertedCusOrgUnitDetail> GetDetailsFromDataBaseAsync()
            {
                var query = from a in (await _convertedCusOrgUnitRepository.GetQueryableAsync())
                            join b in (await _organizationUnitCoordinateRepository.GetQueryableAsync()).WhereIf(!input.RegionCode.IsNullOrEmpty(), it => it.RegionCode == input.RegionCode)
                            on a.Orgidt equals b.OrgNo
                            where a.DataDate == currentDataDate
                            select new ConvertedCusOrgUnitDetailItem
                            {
                                OrgName = b.OrgName,
                                Orgidt = a.Orgidt,
                                Value =
                                a.FirstLevel * coefficient.FirstLevel
                                + a.SecondLevel * coefficient.SecondLevel
                                + a.ThirdLevel * coefficient.ThirdLevel
                                + a.FourthLevel * coefficient.FourthLevel
                                + a.FifthLevel * coefficient.FifthLevel
                                + a.SixthLevel * coefficient.SixthLevel,
                                Lng = b.Longitude,
                                Lat = b.Latitude,
                            };

                return new ConvertedCusOrgUnitDetail { Items = await AsyncExecuter.ToListAsync(query), DataDate = currentDataDate };
            }
        }

        public async Task<ConvertedCusOrgUnitSummary?> GetConvertedCusOrgUnitSummaryAsync(GetConvertedCusOrgUnitSummaryDto input)
        {
            var currentDataDate = input.DataDate ?? await _convertedCusOrgUnitRepository.GetCurrentDataDate();

            var cacheName = $"{currentDataDate:yyyyMMdd}-{nameof(ConvertedCusOrgUnitSummary)}";

            return await _convertedCusOrgUnitSummaryCache.GetOrAddAsync(
                cacheName,
                GetSummaryFromDataBaseAsync,
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = Clock.Now.AddHours(20)
                });

            async Task<ConvertedCusOrgUnitSummary> GetSummaryFromDataBaseAsync()
            {

                var list = await _convertedCusOrgUnitRepository.GetListAsync(it => it.DataDate == currentDataDate);

                var grouped = list.GroupBy(it => new { it.UpOrgidt, it.Label });

                var items = grouped.Select(it => new ConvertedCusOrgUnitSummaryItem
                {
                    UpOrgidt = it.Key.UpOrgidt,
                    Label = it.Key.Label,
                    FirstLevel = it.Sum(it => it.FirstLevel),
                    SecondLevel = it.Sum(it => it.SecondLevel),
                    ThirdLevel = it.Sum(it => it.ThirdLevel),
                    FourthLevel = it.Sum(it => it.FourthLevel),
                    FifthLevel = it.Sum(it => it.FifthLevel),
                    SixthLevel = it.Sum(it => it.SixthLevel)
                }).ToList();

                return new ConvertedCusOrgUnitSummary { Items = items, DataDate = currentDataDate };
            }
        }
    }
}
