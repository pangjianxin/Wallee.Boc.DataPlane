using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Events
{
    public class TDcmpWorkFlowEventHandler : IDistributedEventHandler<TDcmpWorkFlowCompletedEto>, ITransientDependency
    {
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public TDcmpWorkFlowEventHandler(
            TDcmpWorkFlowManager dcmpWorkFlowManager)
        {
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public async Task HandleEventAsync(TDcmpWorkFlowCompletedEto eventData)
        {
            await _tDcmpWorkFlowManager.CreateAsync(eventData.DataDate.AddDays(1).Date, eventData.CronExpression);
        }

    }
}
