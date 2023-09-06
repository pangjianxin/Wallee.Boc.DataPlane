using Cronos;
using Stateless;
using Stateless.Graph;
using Stateless.Reflection;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    public class TDcmpStateMachine
    {
        private enum Trigger
        {
            初始化 = 0,
            加载基础信息 = 1,
            加载地址信息 = 2,

            已完成 = 99
        }

        private StateMachine<TDcmpStatus, Trigger> _stateMachine;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<Guid> _ccicBasic;
        private readonly StateMachine<TDcmpStatus, Trigger>.TriggerWithParameters<Guid> _ccicAddress;
        private readonly TDcmpWorkFlow _tDcmp;
        private readonly DateTime _now;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TDcmpStateMachine(TDcmpWorkFlow tDcmp, IBackgroundJobManager backgroundJobManager, DateTime now)
        {
            _tDcmp = tDcmp;

            _backgroundJobManager = backgroundJobManager;

            _now = now;

            _stateMachine = new StateMachine<TDcmpStatus, Trigger>(() => _tDcmp.Status, _tDcmp.SetStatus);

            _ccicBasic = _stateMachine.SetTriggerParameters<Guid>(Trigger.加载基础信息);

            _ccicAddress = _stateMachine.SetTriggerParameters<Guid>(Trigger.加载地址信息);

            _stateMachine.Configure(TDcmpStatus.初始化)
                .OnActivateAsync(OnStateMachineInitializedAsync, "数据加工开始")
                .Permit(Trigger.加载基础信息, TDcmpStatus.基础信息);

            _stateMachine.Configure(TDcmpStatus.基础信息)
                .OnEntryFromAsync(_ccicBasic, OnCcicBasicCompletedAsync, "第一步")
                .Permit(Trigger.加载地址信息, TDcmpStatus.地址信息);

            _stateMachine.Configure(TDcmpStatus.地址信息)
                .OnEntryFromAsync(_ccicAddress, OnCcicAddressCompletedAsync, "第二步")
                .Permit(Trigger.已完成, TDcmpStatus.已完成);

            //_stateMachine.Configure(TDcmpStatus.已完成)
            //    .OnEntryAsync()
        }

        public string GetDotGraph()
        {
            StateMachineInfo info = _stateMachine.GetInfo();
            return UmlDotGraph.Format(info);
        }

        public async Task NotifyTDcmpWorkFlowInitialized()
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
            var timeSpan = CalculateOccurrence(_now);

            await _backgroundJobManager.EnqueueAsync(new LoadCcicBasicJobArgs()
            {
                WorkFlowId = _tDcmp.Id
            },
            BackgroundJobPriority.Normal,
            delay: timeSpan);
        }

        private async Task OnCcicBasicCompletedAsync(Guid workFlowId)
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicAddressJobArgs()
            {
                WorkFlowId = workFlowId
            },
            BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }

        private Task OnCcicAddressCompletedAsync(Guid workFlowId)
        {
            _tDcmp.Complete();
            _tDcmp.SetComment($"文件处理完毕");
            _stateMachine.Fire(Trigger.已完成);
            return Task.CompletedTask;
        }


        protected TimeSpan CalculateOccurrence(DateTime now)
        {
            var nextFileDateTime = _tDcmp.DataDate.AddDays(1);

            var delay = TimeSpan.FromSeconds(5);

            if (nextFileDateTime.Date >= now.Date)
            {
                var nextTryTimeCron = CronExpression.Parse(_tDcmp.CronExpression);

                var nextTryTime = nextTryTimeCron.GetNextOccurrence((DateTimeOffset)nextFileDateTime.AddDays(1), TimeZoneInfo.Local)!.Value;

                delay = nextTryTime - now;
            }

            return delay;
        }
    }
}
