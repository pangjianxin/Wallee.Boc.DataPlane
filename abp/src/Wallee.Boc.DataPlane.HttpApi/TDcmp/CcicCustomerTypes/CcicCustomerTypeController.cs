using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-customer-type")]
    [Authorize]
    public class CcicCustomerTypeController : DataPlaneController, ICcicCustomerTypeAppService
    {
        private readonly ICcicCustomerTypeAppService _ccicCustomerTypeAppService;

        public CcicCustomerTypeController(ICcicCustomerTypeAppService ccicCustomerTypeAppService)
        {
            _ccicCustomerTypeAppService = ccicCustomerTypeAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{LGPER_CODE}")]
        public async Task<CcicCustomerTypeDto> GetAsync(CcicCustomerTypeKey id)
        {
            return await _ccicCustomerTypeAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicCustomerTypeDto>> GetListAsync(CcicCustomerTypeGetListInput input)
        {
            return await _ccicCustomerTypeAppService.GetListAsync(input);
        }
    }
}
