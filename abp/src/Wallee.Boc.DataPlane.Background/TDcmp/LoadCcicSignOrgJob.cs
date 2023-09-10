using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicSignOrgJob : TDcmpAsyncBackgroundJob<LoadCcicSignOrgJobArgs>, ITransientDependency
    {
        private readonly ICcicSignOrgRepository _ccicSignOrgRepository;
        private readonly TDcmpWorkFlowManager _dcmpWorkFlowManager;

        public LoadCcicSignOrgJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicSignOrgRepository ccicSignOrgRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicSignOrgRepository = ccicSignOrgRepository;
            _dcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        public override Task ExecuteAsync(LoadCcicSignOrgJobArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
