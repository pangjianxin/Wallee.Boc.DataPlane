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

        public async Task<TDcmpWorkFlow> CreateAsync(DateTime dataDate)
        {
            if (await _tDcmpWorkFlowRepository.AnyAsync(it => it.DataDate.Date == dataDate.Date))
            {
                throw new UserFriendlyException("已存在该日期的工作流");
            }

            var workFlow = new TDcmpWorkFlow(GuidGenerator.Create(), dataDate);

            var stateMachine = new TDcmpStateMachine(workFlow, _backgroundJobManager);

            await stateMachine.NotifyTDcmpInitialized();

            workFlow = await _tDcmpWorkFlowRepository.InsertAsync(workFlow, autoSave: true);

            return workFlow;
        }
    }
}
