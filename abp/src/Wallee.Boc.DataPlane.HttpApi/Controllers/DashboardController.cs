
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Dashboard;

namespace Wallee.Boc.DataPlane.Controllers
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.Default)]
    [Route("api/app/sample")]
    public class DashboardController : DataPlaneController, IDashboardAppService
    {
        private readonly IDashboardAppService _dashboardAppService;

        public DashboardController(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        [HttpGet]
        [Route("test")]
        public async Task TestAsync()
        {
            await _dashboardAppService.TestAsync();
        }
    }
}
