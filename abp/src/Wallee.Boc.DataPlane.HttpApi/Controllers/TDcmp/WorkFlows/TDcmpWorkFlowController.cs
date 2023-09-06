using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

namespace Wallee.Boc.DataPlane.Controllers.TDcmp.WorkFlows
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/t-dcmp/work-flow")]
    [Authorize]
    public class TDcmpWorkFlowController : DataPlaneController, ITDcmpWorkFlowAppService
    {
        private readonly ITDcmpWorkFlowAppService _tDcmpWorkFlowAppService;

        public TDcmpWorkFlowController(ITDcmpWorkFlowAppService tDcmpWorkFlowAppService)
        {
            _tDcmpWorkFlowAppService = tDcmpWorkFlowAppService;
        }

        [HttpPost]
        public async Task<TDcmpWorkFlowDto> CreateAsync(CreateUpdateTDcmpWorkFlowDto input)
        {
            return await _tDcmpWorkFlowAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _tDcmpWorkFlowAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TDcmpWorkFlowDto> GetAsync(Guid id)
        {
            return await _tDcmpWorkFlowAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("executing")]
        public async Task<ExecutingTDcmpWorkFlowDto?> GetExecutingAsync()
        {
            return await _tDcmpWorkFlowAppService.GetExecutingAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<TDcmpWorkFlowDto>> GetListAsync(TDcmpWorkFlowGetListInput input)
        {
            return await _tDcmpWorkFlowAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<TDcmpWorkFlowDto> UpdateAsync(Guid id, CreateUpdateTDcmpWorkFlowDto input)
        {
            return await _tDcmpWorkFlowAppService.UpdateAsync(id, input);
        }
    }
}
