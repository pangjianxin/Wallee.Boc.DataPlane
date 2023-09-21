using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Settings;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Events;

namespace Wallee.Boc.DataPlane.WorkFlows.Events
{
    public class CcicCusInfoWorkFlowEventHandler : IDistributedEventHandler<CcicCusInfoWorkFlowCompletedEto>, ITransientDependency
    {
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public CcicCusInfoWorkFlowEventHandler(
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager)
        {
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public async Task HandleEventAsync(CcicCusInfoWorkFlowCompletedEto eventData)
        {
            await _ccicCusInfoWorkFlowManager.CreateAsync(eventData.DataDate.AddDays(1).Date);
        }

    }
}
