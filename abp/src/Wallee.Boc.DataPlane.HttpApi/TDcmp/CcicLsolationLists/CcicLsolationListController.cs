using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/ccic-lsolation-list")]
    [Authorize]
    public class CcicLsolationListController : DataPlaneController, ICcicLsolationListAppService
    {
        private readonly ICcicLsolationListAppService _ccicLsolationListAppService;

        public CcicLsolationListController(ICcicLsolationListAppService ccicLsolationListAppService)
        {
            _ccicLsolationListAppService = ccicLsolationListAppService;
        }

        [HttpGet]
        [Route("{CUSNO}/{LGPER_CODE}")]
        public async Task<CcicLsolationListDto> GetAsync(CcicLsolationListKey id)
        {
            return await _ccicLsolationListAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CcicLsolationListDto>> GetListAsync(CcicLsolationListGetListInput input)
        {
            return await _ccicLsolationListAppService.GetListAsync(input);
        }
    }
}
