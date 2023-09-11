using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicIds.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-id")]
    [Authorize]
    public class CcicIdController : DataPlaneController, ICcicIdAppService
    {
        private readonly ICcicIdAppService _ccicIdAppService;

        public CcicIdController(ICcicIdAppService ccicIdAppService)
        {
            _ccicIdAppService = ccicIdAppService;
        }
        [HttpGet]
        [Route("{CUSNO}/{CRDT_TP}/{CRDT_SN}/{LGPER_CODE}")]
        public async Task<CcicIdDto> GetAsync(CcicIdKey id)
        {
            return await _ccicIdAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicIdDto>> GetListAsync(CcicIdGetListInput input)
        {
            return await _ccicIdAppService.GetListAsync(input);
        }
    }
}
