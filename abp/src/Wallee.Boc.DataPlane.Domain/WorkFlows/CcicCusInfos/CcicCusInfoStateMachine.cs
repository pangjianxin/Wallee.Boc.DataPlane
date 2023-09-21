using Cronos;
using Stateless;
using Stateless.Graph;
using Stateless.Reflection;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos
{
    public class CcicCusInfoStateMachine
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
            加载名称信息 = 9,
            加载人员关系信息 = 10,
            加载电话信息 = 11,
            加载运营信息 = 12,
            加载注册信息 = 13,
            加载重要标志信息组织 = 14,
            已完成 = 99
        }

        private StateMachine<CcicCusInfoWorkFlowStatus, Trigger> _stateMachine;

        private readonly CcicCusInfoWorkFlow _ccicCusInfoWorkFlow;

        private readonly IBackgroundJobManager _backgroundJobManager;

        public string? Cron { get; private set; }
        public DateTime Now { get; private set; }

        public void SetCron(string cron)
        {
            Cron = cron;
        }

        public void SetNow(DateTime now)
        {
            Now = now;
        }
        public CcicCusInfoStateMachine(CcicCusInfoWorkFlow ccicCusInfoWorkFlow, IBackgroundJobManager backgroundJobManager)
        {
            _ccicCusInfoWorkFlow = ccicCusInfoWorkFlow;

            _backgroundJobManager = backgroundJobManager;

            _stateMachine = new StateMachine<CcicCusInfoWorkFlowStatus, Trigger>(() => _ccicCusInfoWorkFlow.Status, _ccicCusInfoWorkFlow.SetStatus);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.初始化)
                .OnActivateAsync(OnStateMachineInitializedAsync, "数据加工开始")
                .Permit(Trigger.加载基础信息, CcicCusInfoWorkFlowStatus.基础信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.基础信息)
                .OnEntryFromAsync(Trigger.加载基础信息, OnCcicBasicCompletedAsync, "第1步")
                .Permit(Trigger.加载地址信息, CcicCusInfoWorkFlowStatus.地址信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.地址信息)
                .OnEntryFromAsync(Trigger.加载地址信息, OnCcicAddressCompletedAsync, "第2步")
                .Permit(Trigger.加载反洗钱信息, CcicCusInfoWorkFlowStatus.反洗钱信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.反洗钱信息)
                .OnEntryFromAsync(Trigger.加载反洗钱信息, OnCcicAntiMoneyLaunderingCompletedAsync, "第3步")
                .Permit(Trigger.加载类别信息, CcicCusInfoWorkFlowStatus.类别信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.类别信息)
                .OnEntryFromAsync(Trigger.加载类别信息, OnCcicCustomerTypeCompletedAsync, "第4步")
                .Permit(Trigger.加载类别信息组织, CcicCusInfoWorkFlowStatus.类别信息组织);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.类别信息组织)
                .OnEntryFromAsync(Trigger.加载类别信息组织, OnCcicCustomerTypeOrgCompletedAsync, "第5步")
                .Permit(Trigger.加载概况信息组织, CcicCusInfoWorkFlowStatus.概况信息组织);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.概况信息组织)
                .OnEntryFromAsync(Trigger.加载概况信息组织, OnCcicGeneralOrgCompletedAsync, "第6步")
                .Permit(Trigger.加载证件信息, CcicCusInfoWorkFlowStatus.证件信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.证件信息)
                .OnEntryFromAsync(Trigger.加载证件信息, OnCcicIdCompletedAsync, "第7步")
                .Permit(Trigger.加载名称信息, CcicCusInfoWorkFlowStatus.名称信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.名称信息)
                .OnEntryFromAsync(Trigger.加载名称信息, OnCcicNameCompletedAsync, "第8步")
                .Permit(Trigger.加载人员关系信息, CcicCusInfoWorkFlowStatus.人员关系信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.人员关系信息)
                .OnEntryFromAsync(Trigger.加载人员关系信息, OnCcicPersonalRelationCompletedAsync, "第9步")
                .Permit(Trigger.加载电话信息, CcicCusInfoWorkFlowStatus.电话信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.电话信息)
                .OnEntryFromAsync(Trigger.加载电话信息, OnCcicPhoneCompletedAsync, "第10步")
                .Permit(Trigger.加载运营信息, CcicCusInfoWorkFlowStatus.运营信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.运营信息)
                .OnEntryFromAsync(Trigger.加载运营信息, OnCcicPracticeCompletedAsync, "第11步")
                .Permit(Trigger.加载注册信息, CcicCusInfoWorkFlowStatus.注册信息);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.注册信息)
                .OnEntryFromAsync(Trigger.加载注册信息, OnCcicRegisterCompletedAsync, "第12步")
                .Permit(Trigger.加载重要标志信息组织, CcicCusInfoWorkFlowStatus.重要标志信息组织);

            _stateMachine.Configure(CcicCusInfoWorkFlowStatus.重要标志信息组织)
                .OnEntryFromAsync(Trigger.加载重要标志信息组织, OnCcicSignOrgCompletedAsync, "第13步")
                .Permit(Trigger.已完成, CcicCusInfoWorkFlowStatus.已完成);
        }

        public string GetDotGraph()
        {
            StateMachineInfo info = _stateMachine.GetInfo();
            return UmlDotGraph.Format(info);
        }

        internal async Task NotifyCcicCusInfoWorkFlowInitialized(DateTime now, string cron)
        {
            SetNow(now);
            SetCron(cron);
            await _stateMachine.ActivateAsync();
        }

        internal async Task NotifyCcicBasicCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载基础信息);
        }

        internal async Task NotifyCcicAddressCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载地址信息);
        }

        internal async Task NotifyCcicAntiMoneyLaunderingCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载反洗钱信息);
        }

        internal async Task NotifyCcicCustomerTypeCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载类别信息);
        }

        internal async Task NotifyCcicCustomerTypeOrgCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载类别信息组织);
        }

        internal async Task NotifyCcicGeneralOrgCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载概况信息组织);
        }

        internal async Task NotifyCcicIdCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载证件信息);
        }

        internal async Task NotifyCcicNameCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载名称信息);
        }

        internal async Task NotifyCcicPersonalRelationCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载人员关系信息);
        }

        internal async Task NotifyCcicPhoneCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载电话信息);
        }

        internal async Task NotifyCcicPracticeCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载运营信息);
        }

        internal async Task NotifyCcicRegisterCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载注册信息);
        }

        internal async Task NotifyCcicSignOrgCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载重要标志信息组织);
        }

        /// <summary>
        /// 处于初始化状态的状态机需要激活一下，以便进入任务执行阶段
        /// </summary>
        /// <returns></returns>
        private async Task OnStateMachineInitializedAsync()
        {
            var timeSpan = CalculateOccurrence();

            await _backgroundJobManager.EnqueueAsync(new LoadCcicBasicJobArgs()
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            },
            BackgroundJobPriority.Normal,
            delay: timeSpan);
        }
        /// <summary>
        /// 第二步，加载地址信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicBasicCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicAddressJobArgs()
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            },
            BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第三步，加载反洗钱信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicAddressCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicAntiMoneyLaunderingJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第四步，加载客户类别
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicAntiMoneyLaunderingCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicCustomerTypeJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
            TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第五步，加载类别组织信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicCustomerTypeCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicCustomerTypeOrgJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
           TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第六步，记载对公概况组织信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicCustomerTypeOrgCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicGeneralOrgJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
           TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第七步，加载证件信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicGeneralOrgCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicIdJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
               TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// 第8步，加载对公名称信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicIdCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicNameJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                           TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第9步，加载人员关系信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicNameCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPersonalRelationJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                         TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第10步，加载对公电话信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPersonalRelationCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPhoneJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                       TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第11步，加载对公运营信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPhoneCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPracticeJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                      TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第12步，加载对公注册信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPracticeCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicRegisterJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                     TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第13步，加载重要标志信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicRegisterCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicSignOrgJobArgs
            {
                WorkFlowId = _ccicCusInfoWorkFlow.Id,
                DataDate = _ccicCusInfoWorkFlow.DataDate
            }, BackgroundJobPriority.Normal,
                                TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第14步，整个流程结束
        /// </summary>
        /// <returns></returns>
        private Task OnCcicSignOrgCompletedAsync()
        {
            _ccicCusInfoWorkFlow.SetComment($"文件处理完毕");
            _stateMachine.Fire(Trigger.已完成);
            return Task.CompletedTask;
        }


        protected TimeSpan CalculateOccurrence()
        {
            var nextFileDateTime = _ccicCusInfoWorkFlow.DataDate.AddDays(1);

            var delay = TimeSpan.FromSeconds(5);

            if (nextFileDateTime.Date >= Now.Date)
            {
                var nextTryTimeCron = CronExpression.Parse(Cron);

                var nextTryTime = nextTryTimeCron.GetNextOccurrence((DateTimeOffset)nextFileDateTime.AddDays(1), TimeZoneInfo.Local)!.Value;

                delay = nextTryTime - Now;
            }

            return delay;
        }
    }
}
