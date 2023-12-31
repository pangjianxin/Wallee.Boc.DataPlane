﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Dashboard;
using Wallee.Boc.DataPlane.Dashboard.Dtos;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.Dashboards
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/dashboard")]
    [Authorize]
    public class DashboardController : DataPlaneController, IDashboardAppService
    {
        private readonly IDashboardAppService _dashboardAppService;

        public DashboardController(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        [HttpGet]
        [Route("converted-cus-org-unit-detail")]
        [Authorize(DataPlanePermissions.Dashboard.ConvertedCusOrgUnit)]
        public async Task<ConvertedCusOrgUnitDetail?> GetConvertedCusOrgUnitDetailsAsync(GetConvertedCusOrgUnitDetailsDto input)
        {
            return await _dashboardAppService.GetConvertedCusOrgUnitDetailsAsync(input);
        }

        [HttpGet]
        [Route("converted-cus-org-unit-summary")]
        [Authorize(DataPlanePermissions.Dashboard.ConvertedCusOrgUnit)]
        public async Task<ConvertedCusOrgUnitSummary?> GetConvertedCusOrgUnitSummaryAsync(GetConvertedCusOrgUnitSummaryDto input)
        {
            return await _dashboardAppService.GetConvertedCusOrgUnitSummaryAsync(input);
        }
    }
}
