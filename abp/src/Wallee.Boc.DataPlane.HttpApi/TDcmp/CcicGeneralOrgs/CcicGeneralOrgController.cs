using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-general-org")]
    [Authorize]
    public class CcicGeneralOrgController : DataPlaneController, ICcicGeneralOrgAppService
    {
        private readonly ICcicGeneralOrgAppService _ccicGeneralOrgAppService;

        public CcicGeneralOrgController(ICcicGeneralOrgAppService ccicGeneralOrgAppService)
        {
            _ccicGeneralOrgAppService = ccicGeneralOrgAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{LGPER_CODE}")]
        public async Task<CcicGeneralOrgDto> GetAsync(CcicGeneralOrgKey id)
        {
            return await _ccicGeneralOrgAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicGeneralOrgDto>> GetListAsync(CcicGeneralOrgGetListInput input)
        {
            return await _ccicGeneralOrgAppService.GetListAsync(input);
        }
    }
}
