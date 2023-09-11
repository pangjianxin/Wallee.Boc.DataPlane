using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-customer-type-org")]
    [Authorize]
    public class CcicCustomerTypeOrgController : DataPlaneController, ICcicCustomerTypeOrgAppService
    {
        private readonly ICcicCustomerTypeOrgAppService _ccicCustomerTypeOrgAppService;

        public CcicCustomerTypeOrgController(ICcicCustomerTypeOrgAppService ccicCustomerTypeOrgAppService)
        {
            _ccicCustomerTypeOrgAppService = ccicCustomerTypeOrgAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{LGPER_CODE}")]
        public async Task<CcicCustomerTypeOrgDto> GetAsync(CcicCustomerTypeOrgKey id)
        {
            return await _ccicCustomerTypeOrgAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicCustomerTypeOrgDto>> GetListAsync(CcicCustomerTypeOrgGetListInput input)
        {
            return await _ccicCustomerTypeOrgAppService.GetListAsync(input);
        }
    }
}
