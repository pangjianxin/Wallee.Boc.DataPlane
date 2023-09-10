using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.CsvHelper;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicLsolationListJob : TDcmpAsyncBackgroundJob<LoadCcicLsolationListJobArgs>, ITransientDependency
    {
        private readonly ICcicLsolationListRepository _ccicLsolationListRepository;
        private readonly ITDcmpWorkFlowRepository _tDcmpWorkFlowRepository;

        public LoadCcicLsolationListJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicLsolationListRepository ccicLsolationListRepository,
            ITDcmpWorkFlowRepository tDcmpWorkFlowRepository) : base(ftpOptions, clock, repository, config)
        {
            _ccicLsolationListRepository = ccicLsolationListRepository;
            _tDcmpWorkFlowRepository = tDcmpWorkFlowRepository;
        }

        public override Task ExecuteAsync(LoadCcicLsolationListJobArgs args)
        {
            throw new NotImplementedException();
        }
    }

    internal class CcicLsolationListMap : ClassMapBase<CcicLsolationList>
    {
        public CcicLsolationListMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.QUARN_STS).Index(2);
            Map(it => it.QUARN_TP).Index(3);
            Map(it => it.QUARN_REASN).Index(4);
            Map(it => it.DEL_FLAG).Index(5);
            Map(it => it.CRTR_TLR_REFNO).Index(6);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(7);
            Map(it => it.CRT_DTTM).Index(8).Convert(it => DateTimeConverter(it.Row, 8, "yyyyMMdd HH:mm:ss:ff")!.Value);
            Map(it => it.CUR_ACDT_PERI).Index(9);
            Map(it => it.LTST_MOD_TLR_REFNO).Index(10);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(11);
            Map(it => it.LAST_MNT_STS_CODE).Index(12);
            Map(it => it.LAST_MOD_DTTM).Index(13).Convert(it => DateTimeConverter(it.Row, 13, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(14);
            Map(it => it.RCRD_CLNUP_STSCD).Index(15);

        }
    }
}
