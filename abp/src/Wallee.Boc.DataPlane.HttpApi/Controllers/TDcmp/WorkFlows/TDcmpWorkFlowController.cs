using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

namespace Wallee.Boc.DataPlane.Controllers.TDcmp.WorkFlows
{
    public class TDcmpWorkFlowController : DataPlaneController, ITDcmpWorkFlowAppService
    {
        private readonly ITDcmpWorkFlowAppService _tDcmpWorkFlowAppService;

        public TDcmpWorkFlowController(ITDcmpWorkFlowAppService tDcmpWorkFlowAppService)
        {
            _tDcmpWorkFlowAppService = tDcmpWorkFlowAppService;
        }

        public Task<TDcmpWorkFlowDto> CreateAsync(CreateUpdateTDcmpWorkFlowDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TDcmpWorkFlowDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<TDcmpWorkFlowDto>> GetListAsync(TDcmpWorkFlowGetListInput input)
        {
            throw new NotImplementedException();
        }

        public Task<TDcmpWorkFlowDto> UpdateAsync(Guid id, CreateUpdateTDcmpWorkFlowDto input)
        {
            throw new NotImplementedException();
        }
    }
}
