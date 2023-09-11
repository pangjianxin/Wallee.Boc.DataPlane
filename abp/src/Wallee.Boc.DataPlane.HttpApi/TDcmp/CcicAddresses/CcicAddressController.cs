using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-address")]
    [Authorize]
    public class CcicAddressController : DataPlaneController, ICcicAddressAppService
    {
        private readonly ICcicAddressAppService _ccicAddressAppService;

        public CcicAddressController(ICcicAddressAppService ccicAddressAppService)
        {
            _ccicAddressAppService = ccicAddressAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{LGPER_CODE}")]
        public async Task<CcicAddressDto> GetAsync(CcicAddressKey id)
        {
            return await _ccicAddressAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicAddressDto>> GetListAsync(CcicAddressGetListInput input)
        {
            return await _ccicAddressAppService.GetListAsync(input);
        }
    }
}
