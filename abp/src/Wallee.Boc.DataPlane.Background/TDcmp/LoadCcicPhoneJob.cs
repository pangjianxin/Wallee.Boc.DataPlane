using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicPhoneJob : TDcmpAsyncBackgroundJob<LoadCcicPhoneJobArgs>, ITransientDependency
    {
        private readonly ICcicPhoneRepository _ccicPhoneRepository;
        private readonly TDcmpWorkFlowManager _dcmpWorkFlowManager;

        public LoadCcicPhoneJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicPhoneRepository ccicPhoneRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicPhoneRepository = ccicPhoneRepository;
            _dcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        public override Task ExecuteAsync(LoadCcicPhoneJobArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
