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

        public Task<TDcmpWorkFlow> NotifyCcicBasicCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            stateMachine.NotifyCcicBasicCompleted();
            return Task.FromResult(tDcmpWorkFlow);
        }

        public Task<TDcmpWorkFlow> NotifyCcicAddressCompletedAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            stateMachine.NotifyCcicAddressCompleted();
            return Task.FromResult(tDcmpWorkFlow);
        }

        public Task<string> GetDotGraphAsync(TDcmpWorkFlow tDcmpWorkFlow)
        {
            var stateMachine = new TDcmpStateMachine(tDcmpWorkFlow, _backgroundJobManager, Clock.Now);
            return Task.FromResult(stateMachine.GetDotGraph());
        }
    }
}
