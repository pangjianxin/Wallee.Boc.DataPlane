﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Dashboard;
using Wallee.Boc.DataPlane.Dashboard.Dtos;

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
        [Route("converted-cus-org-unit-detail")]
        public async Task<ConvertedCusOrgUnitDetail?> GetConvertedCusOrgUnitDetailsAsync(DateTime? dataDate)
        {
            return await _dashboardAppService.GetConvertedCusOrgUnitDetailsAsync(dataDate);
        }

        [HttpGet]
        [Route("converted-cus-org-unit-summary")]
        public async Task<ConvertedCusOrgUnitSummary?> GetConvertedCusOrgUnitSummaryAsync(DateTime? dataDate)
        {
            return await _dashboardAppService.GetConvertedCusOrgUnitSummaryAsync(dataDate);
        }
    }
}
