using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicRegisterJob : TDcmpAsyncBackgroundJob<LoadCcicRegisterJobArgs>, ITransientDependency
    {
        private readonly ICcicRegisterRepository _ccicRegisterRepository;
        private readonly TDcmpWorkFlowManager _dcmpWorkFlowManager;

        public LoadCcicRegisterJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicRegisterRepository ccicRegisterRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicRegisterRepository = ccicRegisterRepository;
            _dcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        public override Task ExecuteAsync(LoadCcicRegisterJobArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
