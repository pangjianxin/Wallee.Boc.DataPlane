
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Dashboard;

namespace Wallee.Boc.DataPlane.Dashboards
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/dashboard")]
    public class DashboardController : DataPlaneController, IDashboardAppService
    {
        private readonly IDashboardAppService _dashboardAppService;

        public DashboardController(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        [HttpGet]
        [Route("converted-cus-org-unit-info")]
        public Task GetConvertedCusOrgUnitInfoAsync(DateTime dataDate)
        {
            return _dashboardAppService.GetConvertedCusOrgUnitInfoAsync(dataDate);
        }
    }
}
