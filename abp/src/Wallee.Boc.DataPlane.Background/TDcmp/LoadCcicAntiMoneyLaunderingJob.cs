using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicAntiMoneyLaunderingJob : TDcmpAsyncBackgroundJob<LoadCcicAntiMoneyLaunderingJobArgs>, ITransientDependency
    {
        private readonly ICcicAntiMoneyLaunderingRepository _ccicAntiMoneyLaunderingRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicAntiMoneyLaunderingJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ITDcmpWorkFlowRepository repository,
            IConfiguration config,
            ICcicAntiMoneyLaunderingRepository ccicAntiMoneyLaunderingRepository,
            TDcmpWorkFlowManager tDcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicAntiMoneyLaunderingRepository = ccicAntiMoneyLaunderingRepository;
            _tDcmpWorkFlowManager = tDcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicAntiMoneyLaunderingJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);

            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicAntiMoneyLaunderingFileName);

                await UpsertAsync(stream, _ccicAntiMoneyLaunderingRepository, typeof(CcicAntiMoneyLaunderingMap));

                await _tDcmpWorkFlowManager.NotifyCcicAntiMoneyLaunderingCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }
    internal class CcicAntiMoneyLaunderingMap : ClassMapBase<CcicAntiMoneyLaundering>
    {
        public CcicAntiMoneyLaunderingMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.AML_INF_SN).Index(1);
            Map(it => it.LGPER_CODE).Index(2);
            Map(it => it.EXPC_MO_TXN_SZ_AMT).Index(3);
            Map(it => it.EXPC_MO_TXN_SZ_CUR).Index(4);
            Map(it => it.CRRCUS_CODE).Index(5);
            Map(it => it.SDD_CUS_TP).Index(6);
            Map(it => it.TE_CUSRL_PPS).Index(7);
            Map(it => it.PURPOSE_REMARK).Index(8);
            Map(it => it.BENEO_ID_INFO).Index(9);
            Map(it => it.CANNO_ID_BENEO_REASN).Index(10);
            Map(it => it.EXST_EXT_SANCT_NMLST_FLAG).Index(11);
            Map(it => it.POLI_FLAG).Index(12);
            Map(it => it.CRR_RSK_GRD_CODE).Index(13);
            Map(it => it.AML_RSK_GRD_VLD_START_DT).Index(14).Convert(it => DateTimeConverter(it.Row, 14, "yyyyMMdd"));
            Map(it => it.AML_RSK_GRD_VLD_TMT_DT).Index(15).Convert(it => DateTimeConverter(it.Row, 15, "yyyyMMdd"));
            Map(it => it.DEL_FLAG).Index(16);
            Map(it => it.CRTR_TLR_REFNO).Index(17);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(18);
            Map(it => it.CRT_DTTM).Index(19).Convert(it => DateTimeConverter(it.Row, 19, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(20).Convert(it => DateTimeConverter(it.Row, 20, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(21);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(22);
            Map(it => it.LAST_MNT_STS_CODE).Index(23);
            Map(it => it.LAST_MOD_DTTM).Index(24).Convert(it => DateTimeConverter(it.Row, 24, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(25);
            Map(it => it.RCRD_CLNUP_STSCD).Index(26);
        }
    }
}
