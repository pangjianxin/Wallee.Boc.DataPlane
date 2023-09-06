using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Timing;
using Volo.Abp.Uow;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Events
{
    public class TDcmpWorkFlowEventHandler : IDistributedEventHandler<TDcmpWorkFlowCompletedEto>
    {
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;
        private readonly IClock _clock;

        public TDcmpWorkFlowEventHandler(
            TDcmpWorkFlowManager dcmpWorkFlowManager,
            IClock clock)
        {
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
            _clock = clock;
        }

        [UnitOfWork]
        public async Task HandleEventAsync(TDcmpWorkFlowCompletedEto eventData)
        {
            await _tDcmpWorkFlowManager.CreateAsync(eventData.DataDate.AddDays(1).Date, eventData.CronExpression);
        }

    }
}
