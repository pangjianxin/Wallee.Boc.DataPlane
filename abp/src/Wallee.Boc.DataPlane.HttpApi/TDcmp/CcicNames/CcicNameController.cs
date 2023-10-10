using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicNames.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-name")]
    [Authorize]
    public class CcicNameController : DataPlaneController, ICcicNameAppService
    {
        private readonly ICcicNameAppService _ccicNameAppService;

        public CcicNameController(ICcicNameAppService ccicNameAppService)
        {
            _ccicNameAppService = ccicNameAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{CUS_NAME_LANG}/{LGPER_CODE}")]
        [Authorize(DataPlanePermissions.TDcmpReports.CcicName)]
        public async Task<CcicNameDto> GetAsync(CcicNameKey id)
        {
            return await _ccicNameAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(DataPlanePermissions.TDcmpReports.CcicName)]
        public async Task<PagedResultDto<CcicNameDto>> GetListAsync(CcicNameGetListInput input)
        {
            return await _ccicNameAppService.GetListAsync(input);
        }
    }
}
