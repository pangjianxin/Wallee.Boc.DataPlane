using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Wallee.Boc.DataPlane.Dashboard.Dtos;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public class DashboardAppService : DataPlaneAppService, IDashboardAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IDistributedCache<ConvertedCusOrgUnitInfoCache> _convertedCusOrgUnitInfoCache;

        public DashboardAppService(
            IBackgroundJobManager backgroundJobManager,
            IDistributedCache<ConvertedCusOrgUnitInfoCache> convertedCusOrgUnitInfoCache)
        {
            _backgroundJobManager = backgroundJobManager;
            _convertedCusOrgUnitInfoCache = convertedCusOrgUnitInfoCache;
        }

        public Task GetConvertedCusOrgUnitInfoAsync(DateTime dataDate)
        {
            throw new NotImplementedException();
        }
    }
}
