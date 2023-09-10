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
            初始化 = 1,
            加载基础信息 = 2,
            加载地址信息 = 3,
            加载反洗钱信息 = 4,
            加载类别信息 = 5,
            加载类别信息组织 = 6,
            加载概况信息组织 = 7,
            加载证件信息 = 8,
            加载隔离清单信息 = 9,
            加载名称信息 = 10,
            加载人员关系信息 = 11,
            加载电话信息 = 12,
            加载运营信息 = 13,
            加载注册信息 = 14,
            加载重要标志信息组织 = 15,
            已完成 = 99
        }

        private StateMachine<TDcmpStatus, Trigger> _stateMachine;

        private readonly TDcmpWorkFlow _tDcmp;
        private readonly DateTime _now;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TDcmpStateMachine(TDcmpWorkFlow tDcmp, IBackgroundJobManager backgroundJobManager, DateTime now)
        {
            _tDcmp = tDcmp;

            _backgroundJobManager = backgroundJobManager;

            _now = now;

            _stateMachine = new StateMachine<TDcmpStatus, Trigger>(() => _tDcmp.Status, _tDcmp.SetStatus);

            _stateMachine.Configure(TDcmpStatus.初始化)
                .OnActivateAsync(OnStateMachineInitializedAsync, "数据加工开始")
                .Permit(Trigger.加载基础信息, TDcmpStatus.基础信息);

            _stateMachine.Configure(TDcmpStatus.基础信息)
                .OnEntryFromAsync(Trigger.加载基础信息, OnCcicBasicCompletedAsync, "第一步")
                .Permit(Trigger.加载地址信息, TDcmpStatus.地址信息);

            _stateMachine.Configure(TDcmpStatus.地址信息)
                .OnEntryFromAsync(Trigger.加载地址信息, OnCcicAddressCompletedAsync, "第二步")
                .Permit(Trigger.已完成, TDcmpStatus.已完成);
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

        public async Task NotifyCcicBasicCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载基础信息);
        }

        public async Task NotifyCcicAddressCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载地址信息);
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            },
            BackgroundJobPriority.Normal,
            delay: timeSpan);
        }

        private async Task OnCcicBasicCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicAddressJobArgs()
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            },
            BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }

        private Task OnCcicAddressCompletedAsync()
        {
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
