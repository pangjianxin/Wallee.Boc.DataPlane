using Stateless;
using Stateless.Graph;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    public class TDcmpStateMachine
    {
        private enum Trigger
        {
            Init = 0,
            加载对公基础信息 = 1,
            加载对公地址信息 = 2,
        }

        private StateMachine<TDcmpStatus, Trigger> _stateMachine;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<DateTime> _ccicAddress;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<DateTime> _ccicBasic;
        private TDcmpWorkFlow _tDcmp;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TDcmpStateMachine(TDcmpWorkFlow tDcmp, IBackgroundJobManager backgroundJobManager)
        {
            _tDcmp = tDcmp;

            _backgroundJobManager = backgroundJobManager;

            _stateMachine = new StateMachine<TDcmpStatus, Trigger>(() => _tDcmp.Status, _tDcmp.SetStatus);

            _ccicBasic = _stateMachine.SetTriggerParameters<DateTime>(Trigger.加载对公基础信息);

            _ccicAddress = _stateMachine.SetTriggerParameters<DateTime>(Trigger.加载对公地址信息);

            _stateMachine.Configure(TDcmpStatus.初始化)
                .OnActivateAsync(OnStateMachineInitializedAsync)
                .Permit(Trigger.加载对公基础信息, TDcmpStatus.对公基础信息);

            _stateMachine.Configure(TDcmpStatus.对公基础信息)
                .OnEntryFromAsync(_ccicBasic, OnCcicBasicCompletedAsync)
                .Permit(Trigger.加载对公地址信息, TDcmpStatus.对公地址信息);

            _stateMachine.Configure(TDcmpStatus.对公地址信息)
                .OnEntryFromAsync(_ccicAddress, OnCcicAddressCompletedAsync);
        }

        public string GetDotGraph()
        {
            return UmlDotGraph.Format(_stateMachine.GetInfo());
        }

        public async Task NotifyTDcmpInitialized()
        {
            await _stateMachine.ActivateAsync();
        }

        public void NotifyCcicBasicCompleted()
        {
            _stateMachine.Fire(_ccicBasic, _tDcmp.DataDate);
        }

        public void NotifyCcicAddressCompleted()
        {
            _stateMachine.Fire(_ccicAddress, _tDcmp.DataDate);
        }

        /// <summary>
        /// 处于初始化状态的状态机需要激活一下，以便进入任务执行阶段
        /// </summary>
        /// <returns></returns>
        private async Task OnStateMachineInitializedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicBasicJobArgs()
            {
                DataDate = _tDcmp.DataDate
            },
            BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }

        private async Task OnCcicBasicCompletedAsync(DateTime dataDate)
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicAddressJobArgs()
            {
                DataDate = dataDate
            },
            BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }

        private Task OnCcicAddressCompletedAsync(DateTime dataDate)
        {
            //await _backgroundJobManager.EnqueueAsync(new loadccicadd)
            throw new NotImplementedException();
        }
    }
}
