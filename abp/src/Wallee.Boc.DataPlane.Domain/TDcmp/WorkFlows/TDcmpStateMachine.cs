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
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

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
                .OnEntryFromAsync(Trigger.加载基础信息, OnCcicBasicCompletedAsync, "第1步")
                .Permit(Trigger.加载地址信息, TDcmpStatus.地址信息);

            _stateMachine.Configure(TDcmpStatus.地址信息)
                .OnEntryFromAsync(Trigger.加载地址信息, OnCcicAddressCompletedAsync, "第2步")
                .Permit(Trigger.加载反洗钱信息, TDcmpStatus.反洗钱信息);

            _stateMachine.Configure(TDcmpStatus.反洗钱信息)
                .OnEntryFromAsync(Trigger.加载反洗钱信息, OnCcicAntiMoneyLaunderingCompletedAsync, "第3步")
                .Permit(Trigger.加载类别信息, TDcmpStatus.类别信息);

            _stateMachine.Configure(TDcmpStatus.类别信息)
                .OnEntryFromAsync(Trigger.加载类别信息, OnCcicCustomerTypeCompletedAsync, "第4步")
                .Permit(Trigger.加载类别信息组织, TDcmpStatus.类别信息组织);

            _stateMachine.Configure(TDcmpStatus.类别信息组织)
                .OnEntryFromAsync(Trigger.加载类别信息组织, OnCcicCustomerTypeOrgCompletedAsync, "第5步")
                .Permit(Trigger.加载概况信息组织, TDcmpStatus.概况信息组织);

            _stateMachine.Configure(TDcmpStatus.概况信息组织)
                .OnEntryFromAsync(Trigger.加载概况信息组织, OnCcicGeneralOrgCompletedAsync, "第6步")
                .Permit(Trigger.加载证件信息, TDcmpStatus.证件信息);

            _stateMachine.Configure(TDcmpStatus.证件信息)
                .OnEntryFromAsync(Trigger.加载证件信息, OnCcicIdCompletedAsync, "第7步")
                .Permit(Trigger.加载隔离清单信息, TDcmpStatus.隔离清单信息);

            _stateMachine.Configure(TDcmpStatus.隔离清单信息)
                .OnEntryFromAsync(Trigger.加载隔离清单信息, OnCcicLsolationListCompletedAsync, "第8步")
                .Permit(Trigger.加载名称信息, TDcmpStatus.名称信息);

            _stateMachine.Configure(TDcmpStatus.名称信息)
                .OnEntryFromAsync(Trigger.加载名称信息, OnCcicNameCompletedAsync, "第9步")
                .Permit(Trigger.加载人员关系信息, TDcmpStatus.人员关系信息);

            _stateMachine.Configure(TDcmpStatus.人员关系信息)
                .OnEntryFromAsync(Trigger.加载人员关系信息, OnCcicPersonalRelationCompletedAsync, "第10步")
                .Permit(Trigger.加载电话信息, TDcmpStatus.电话信息);

            _stateMachine.Configure(TDcmpStatus.电话信息)
                .OnEntryFromAsync(Trigger.加载电话信息, OnCcicPhoneCompletedAsync, "第11步")
                .Permit(Trigger.加载运营信息, TDcmpStatus.运营信息);

            _stateMachine.Configure(TDcmpStatus.运营信息)
                .OnEntryFromAsync(Trigger.加载运营信息, OnCcicPracticeCompletedAsync, "第12步")
                .Permit(Trigger.加载注册信息, TDcmpStatus.注册信息);

            _stateMachine.Configure(TDcmpStatus.注册信息)
                .OnEntryFromAsync(Trigger.加载注册信息, OnCcicRegisterCompletedAsync, "第13步")
                .Permit(Trigger.加载重要标志信息组织, TDcmpStatus.重要标志信息组织);

            _stateMachine.Configure(TDcmpStatus.重要标志信息组织)
                .OnEntryFromAsync(Trigger.加载重要标志信息组织, OnCcicSignOrgCompletedAsync, "第14步")
                .Permit(Trigger.已完成, TDcmpStatus.已完成);
        }

        public string GetDotGraph()
        {
            StateMachineInfo info = _stateMachine.GetInfo();
            return UmlDotGraph.Format(info);
        }

        internal async Task NotifyTDcmpWorkFlowInitialized()
        {
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

        internal async Task NotifyCcicLsolationListCompletedAsync()
        {
            await _stateMachine.FireAsync(Trigger.加载隔离清单信息);
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
            var timeSpan = CalculateOccurrence(_now);

            await _backgroundJobManager.EnqueueAsync(new LoadCcicBasicJobArgs()
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
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
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
               TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第八步，加载隔离清单信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicIdCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicLsolationListJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
               TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第九步，加载对公名称信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicLsolationListCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicNameJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                           TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十步，加载人员关系信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicNameCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPersonalRelationJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                         TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十一步，加载对公电话信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPersonalRelationCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPhoneJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                       TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十二步，加载对公运营信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPhoneCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicPracticeJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                      TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十三步，加载对公注册信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicPracticeCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicRegisterJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                     TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十四步，加载重要标志信息
        /// </summary>
        /// <returns></returns>
        private async Task OnCcicRegisterCompletedAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new LoadCcicSignOrgJobArgs
            {
                WorkFlowId = _tDcmp.Id,
                DataDate = _tDcmp.DataDate
            }, BackgroundJobPriority.Normal,
                                TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// 第十五步，整个流程结束
        /// </summary>
        /// <returns></returns>
        private Task OnCcicSignOrgCompletedAsync()
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
