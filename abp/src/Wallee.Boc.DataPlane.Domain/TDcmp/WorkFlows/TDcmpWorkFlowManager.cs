using Stateless;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    public class TDcmpWorkFlowManager : DomainService, ITransientDependency
    {
        private readonly ITDcmpWorkFlowRepository _tDcmpWorkFlowRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TDcmpWorkFlowManager(
            ITDcmpWorkFlowRepository tDcmpWorkFlowRepository,
            IBackgroundJobManager backgroundJobManager)
        {
            _tDcmpWorkFlowRepository = tDcmpWorkFlowRepository;
            _backgroundJobManager = backgroundJobManager;
        }

        public async Task<TDcmpWorkFlow> CreateAsync(DateTime dataDate, string cronExpression)
        {
            Check.NotNullOrEmpty(cronExpression, nameof(cronExpression));

            if (await _tDcmpWorkFlowRepository.AnyAsync(it => it.DataDate.Date == dataDate.Date))
            {
                throw new UserFriendlyException("已存在该日期的工作流");
            }

            var workFlow = new TDcmpWorkFlow(GuidGenerator.Create(), dataDate, cronExpression);

            var stateMachine = new TDcmpStateMachine(workFlow, _backgroundJobManager, Clock.Now);

            await stateMachine.NotifyTDcmpWorkFlowInitialized();

            workFlow = await _tDcmpWorkFlowRepository.InsertAsync(workFlow, autoSave: true);

            return workFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicBasicCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicBasicCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicAddressCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicAddressCompletedAsync();
            return tDcmpWorkFlow;
        }


        public async Task<TDcmpWorkFlow> NotifyCcicAntiMoneyLaunderingCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicAntiMoneyLaunderingCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicCustomerTypeCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicCustomerTypeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicCustomerTypeOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicCustomerTypeOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicGeneralOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicGeneralOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicIdCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicIdCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicLsolationListCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicLsolationListCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicNameCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicNameCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPersonalRelationCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicPersonalRelationCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPhoneCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicPhoneCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPracticeCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicPracticeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicRegisterCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicRegisterCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicSignOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            await stateMachine.NotifyCcicSignOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public Task<string> GetDotGraphAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            return Task.FromResult(stateMachine.GetDotGraph());
        }
    }
}
