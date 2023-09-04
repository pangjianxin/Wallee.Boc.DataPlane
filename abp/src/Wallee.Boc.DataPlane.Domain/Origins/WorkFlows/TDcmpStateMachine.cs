using Stateless;
using Stateless.Graph;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.Origins.CcicBasics;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.Origins.WorkFlows
{
    public class TDcmpStateMachine
    {
        private enum Trigger
        {
            加载对公基础信息 = 1,
            加载对公地址信息 = 2,
        }

        private StateMachine<TDcmpStatus, Trigger> _stateMachine;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<DateTime> _ccicAddress;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<DateTime> _ccicBasic;
        private TDcmp _tDcmp;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TDcmpStateMachine(TDcmp tDcmp, IBackgroundJobManager backgroundJobManager)
        {
            _tDcmp = tDcmp;
            _backgroundJobManager = backgroundJobManager;
            _stateMachine = new StateMachine<TDcmpStatus, Trigger>(() => _tDcmp.Status, _tDcmp.SetStatus);

            _ccicBasic = _stateMachine.SetTriggerParameters<DateTime>(Trigger.加载对公基础信息);

            _ccicAddress = _stateMachine.SetTriggerParameters<DateTime>(Trigger.加载对公地址信息);

            _stateMachine.Configure(TDcmpStatus.初始化)
                .Permit(Trigger.加载对公基础信息, TDcmpStatus.对公基础信息);

            _stateMachine.Configure(TDcmpStatus.对公基础信息)
                .OnEntryFromAsync(_ccicBasic, OnCcicBasicFinishedAsync)
                .Permit(Trigger.加载对公地址信息, TDcmpStatus.对公地址信息);
        }

        public string GetDotGraph()
        {
            return UmlDotGraph.Format(_stateMachine.GetInfo());
        }

        public void NotifyCcicBasicFinishedAsync(DateTime dataDate)
        {
            _stateMachine.Fire(_ccicBasic, dataDate);
        }

        private async Task OnCcicBasicFinishedAsync(DateTime dataDate)
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicBasicJobArgs());
        }
    }
}
