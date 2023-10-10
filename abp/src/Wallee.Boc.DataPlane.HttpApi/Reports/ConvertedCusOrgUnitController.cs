using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;

namespace Wallee.Boc.DataPlane.Reports
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/reports/converted-cus-org-unit")]
    [Authorize]
    public class ConvertedCusOrgUnitController : DataPlaneController, IConvertedCusOrgUnitAppService
    {
        private readonly IConvertedCusOrgUnitAppService _convertedCusOrgUnitAppService;

        public ConvertedCusOrgUnitController(IConvertedCusOrgUnitAppService convertedCusOrgUnitAppService)
        {
            _convertedCusOrgUnitAppService = convertedCusOrgUnitAppService;
        }

        [HttpPost]
        [Route("create-by-file")]
        [Authorize(DataPlanePermissions.Reports.ConvertedCusOrgUnit)]
        public async Task CreateByFileAsync(CreateUpdateConvertedCusOrgUnitByFileDto input)
        {
            await _convertedCusOrgUnitAppService.CreateByFileAsync(input);
        }

        [HttpGet]
        [Route("precheck-date")]
        [Authorize(DataPlanePermissions.Reports.ConvertedCusOrgUnit)]
        public async Task<bool> DataExistedAsync(DateTime dataDate)
        {
            return await _convertedCusOrgUnitAppService.DataExistedAsync(dataDate);
        }

        [HttpGet]
        [Route("download/{dataDate}")]
        [Authorize(DataPlanePermissions.Reports.ConvertedCusOrgUnit)]
        public async Task<IRemoteStreamContent> DownloadFileAsync(DateTime dataDate)
        {
            return await _convertedCusOrgUnitAppService.DownloadFileAsync(dataDate);
        }

        [HttpGet]
        [Route("{DataDate}/{Orgidt}")]
        [Authorize(DataPlanePermissions.Reports.ConvertedCusOrgUnit)]
        public async Task<ConvertedCusOrgUnitDto> GetAsync(ConvertedCusOrgUnitKey id)
        {
            return await _convertedCusOrgUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        [Authorize(DataPlanePermissions.Reports.ConvertedCusOrgUnit)]
        public async Task<PagedResultDto<ConvertedCusOrgUnitDto>> GetListAsync(ConvertedCusOrgUnitGetListInput input)
        {
            return await _convertedCusOrgUnitAppService.GetListAsync(input);
        }
    }
}
