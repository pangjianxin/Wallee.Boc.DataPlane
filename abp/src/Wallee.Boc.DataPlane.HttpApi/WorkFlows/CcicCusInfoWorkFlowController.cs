using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.WorkFlows
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/work-flows/ccic-cus-info")]
    [Authorize]
    public class CcicCusInfoWorkFlowController : DataPlaneController, ICcicCusInfoWorkFlowAppService
    {
        private readonly ICcicCusInfoWorkFlowAppService _ccicCusInfoWorkFlowAppService;

        public CcicCusInfoWorkFlowController(ICcicCusInfoWorkFlowAppService tDcmpWorkFlowAppService)
        {
            _ccicCusInfoWorkFlowAppService = tDcmpWorkFlowAppService;
        }

        [HttpPost]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task<CcicCusInfoWorkFlowDto> CreateAsync(CreateUpdateCcicCusInfoWorkFlowDto input)
        {
            return await _ccicCusInfoWorkFlowAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task DeleteAsync(Guid id)
        {
            await _ccicCusInfoWorkFlowAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task<CcicCusInfoWorkFlowDto> GetAsync(Guid id)
        {
            return await _ccicCusInfoWorkFlowAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("executing")]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task<ExecutingCcicCusInfoWorkFlowDto?> GetExecutingAsync()
        {
            return await _ccicCusInfoWorkFlowAppService.GetExecutingAsync();
        }

        [HttpGet]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task<PagedResultDto<CcicCusInfoWorkFlowDto>> GetListAsync(CcicCusInfoWorkFlowGetListInput input)
        {
            return await _ccicCusInfoWorkFlowAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(DataPlanePermissions.WorkFlows.CcicCusInfo)]
        public async Task<CcicCusInfoWorkFlowDto> UpdateAsync(Guid id, CreateUpdateCcicCusInfoWorkFlowDto input)
        {
            return await _ccicCusInfoWorkFlowAppService.UpdateAsync(id, input);
        }
    }
}
