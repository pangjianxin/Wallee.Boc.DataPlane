using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Settings;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos
{
    public class CcicCusInfoWorkFlowManager : DomainService, ITransientDependency
    {
        private readonly ICcicCusInfoWorkFlowRepository _ccicCusInfoWorkFlowRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly ISettingProvider _settingProvider;

        public CcicCusInfoWorkFlowManager(
            ICcicCusInfoWorkFlowRepository tDcmpWorkFlowRepository,
            IBackgroundJobManager backgroundJobManager,
            ISettingProvider settingProvider)
        {
            _ccicCusInfoWorkFlowRepository = tDcmpWorkFlowRepository;
            _backgroundJobManager = backgroundJobManager;
            _settingProvider = settingProvider;
        }

        public async Task<CcicCusInfoWorkFlow> CreateAsync(DateTime dataDate)
        {
            if (await _ccicCusInfoWorkFlowRepository.AnyAsync(it => it.DataDate.Date == dataDate.Date))
            {
                throw new UserFriendlyException("已存在该日期的工作流");
            }

            var workFlow = new CcicCusInfoWorkFlow(GuidGenerator.Create(), dataDate);

            var cron = await _settingProvider.GetOrNullAsync(Settings.DataPlaneSettings.TDcmpWorkFlowCronExpression);

            var stateMachine = new CcicCusInfoStateMachine(workFlow, _backgroundJobManager);

            await stateMachine.NotifyCcicCusInfoWorkFlowInitialized(Clock.Now, cron);

            workFlow = await _ccicCusInfoWorkFlowRepository.InsertAsync(workFlow, autoSave: true);

            return workFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicBasicCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicBasicCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicAddressCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicAddressCompletedAsync();
            return tDcmpWorkFlow;
        }


        public async Task<CcicCusInfoWorkFlow> NotifyCcicAntiMoneyLaunderingCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicAntiMoneyLaunderingCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicCustomerTypeCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicCustomerTypeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicCustomerTypeOrgCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicCustomerTypeOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicGeneralOrgCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicGeneralOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicIdCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicIdCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicNameCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicNameCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicPersonalRelationCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPersonalRelationCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicPhoneCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPhoneCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicPracticeCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicPracticeCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicRegisterCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicRegisterCompletedAsync();
            return tDcmpWorkFlow;
        }

        public async Task<CcicCusInfoWorkFlow> NotifyCcicSignOrgCompletedAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            await stateMachine.NotifyCcicSignOrgCompletedAsync();
            return tDcmpWorkFlow;
        }

        public Task<string> GetDotGraphAsync(CcicCusInfoWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new CcicCusInfoStateMachine(tDcmpWorkFlow, _backgroundJobManager);
            return Task.FromResult(stateMachine.GetDotGraph());
        }
    }
}
