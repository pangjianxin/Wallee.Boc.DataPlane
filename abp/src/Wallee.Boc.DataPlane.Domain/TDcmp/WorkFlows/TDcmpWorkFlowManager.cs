using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Settings;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    public class TDcmpWorkFlowManager : DomainService, ITransientDependency
    {
        private readonly ITDcmpWorkFlowRepository _tDcmpWorkFlowRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly ISettingProvider _settingProvider;

        public TDcmpWorkFlowManager(
            ITDcmpWorkFlowRepository tDcmpWorkFlowRepository,
            IBackgroundJobManager backgroundJobManager,
            ISettingProvider settingProvider)
        {
            _tDcmpWorkFlowRepository = tDcmpWorkFlowRepository;
            _backgroundJobManager = backgroundJobManager;
            _settingProvider = settingProvider;
        }

        public async Task<TDcmpWorkFlow> CreateAsync(DateTime dataDate)
        {
            if (await _tDcmpWorkFlowRepository.AnyAsync(it => it.DataDate.Date == dataDate.Date))
            {
                throw new UserFriendlyException("已存在该日期的工作流");
            }

            var workFlow = new TDcmpWorkFlow(GuidGenerator.Create(), dataDate);

            var cron = await _settingProvider.GetOrNullAsync(Settings.DataPlaneSettings.TDcmpWorkFlowCronExpression);

            var stateMachine = new TDcmpStateMachine(workFlow, _backgroundJobManager);

            await stateMachine.NotifyTDcmpWorkFlowInitialized(Clock.Now, cron);

            workFlow = await _tDcmpWorkFlowRepository.InsertAsync(workFlow, autoSave: true);

            return workFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicBasicCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicBasicCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicAddressCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicAddressCompletedAsync();
            return tDcmpWorkFlow;
        }


        public async Task<TDcmpWorkFlow> NotifyCcicAntiMoneyLaunderingCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicAntiMoneyLaunderingCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicCustomerTypeCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicCustomerTypeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicCustomerTypeOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicCustomerTypeOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicGeneralOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicGeneralOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicIdCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicIdCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicNameCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicNameCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPersonalRelationCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPersonalRelationCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPhoneCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPhoneCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicPracticeCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPracticeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicRegisterCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicRegisterCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<TDcmpWorkFlow> NotifyCcicSignOrgCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicSignOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public Task<string> GetDotGraphAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            return Task.FromResult(stateMachine.GetDotGraph());
        }
    }
}
