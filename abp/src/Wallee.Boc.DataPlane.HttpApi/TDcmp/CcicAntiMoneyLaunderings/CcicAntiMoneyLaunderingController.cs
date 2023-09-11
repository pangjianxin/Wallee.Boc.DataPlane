using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-anti-money-laundering")]
    [Authorize]
    public class CcicAntiMoneyLaunderingController : DataPlaneController, ICcicAntiMoneyLaunderingAppService
    {
        private readonly ICcicAntiMoneyLaunderingAppService _ccicAntiMoneyLaunderingAppService;

        public CcicAntiMoneyLaunderingController(ICcicAntiMoneyLaunderingAppService ccicAntiMoneyLaunderingAppService)
        {
            _ccicAntiMoneyLaunderingAppService = ccicAntiMoneyLaunderingAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{AML_INF_SN}/{LGPER_CODE}")]
        public async Task<CcicAntiMoneyLaunderingDto> GetAsync(CcicAntiMoneyLaunderingKey id)
        {
            return await _ccicAntiMoneyLaunderingAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicAntiMoneyLaunderingDto>> GetListAsync(CcicAntiMoneyLaunderingGetListInput input)
        {
            return await _ccicAntiMoneyLaunderingAppService.GetListAsync(input);
        }
    }
}
