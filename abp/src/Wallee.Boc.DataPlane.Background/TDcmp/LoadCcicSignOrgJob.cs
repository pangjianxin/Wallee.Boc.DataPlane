using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.CsvHelper;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicSignOrgJob : TDcmpAsyncBackgroundJob<LoadCcicSignOrgJobArgs>, ITransientDependency
    {
        private readonly ICcicSignOrgRepository _ccicSignOrgRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicSignOrgJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicSignOrgRepository ccicSignOrgRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicSignOrgRepository = ccicSignOrgRepository;
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicSignOrgJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicSignOrgFileName);

                await UpsertAsync(stream, _ccicSignOrgRepository, typeof(CcicSignOrgMap));

                await _tDcmpWorkFlowManager.NotifyCcicSignOrgCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicSignOrgMap : ClassMapBase<CcicSignOrg>
    {
        public CcicSignOrgMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.SUPR_UNIT_LGPER_PNP_TP).Index(2);
            Map(it => it.LSTCO_FLAG).Index(3);
            Map(it => it.HTCHE_FLAG).Index(4);
            Map(it => it.EXMPT_RGS_SOC_GROU_FLAG).Index(5);
            Map(it => it.NON_PFT_PROP_ORG_FLAG).Index(6);
            Map(it => it.SERIS_ILLG_RCRD_FLAG).Index(7);
            Map(it => it.PS_LIT_FTA_WITH_FLAG).Index(8);
            Map(it => it.PUBEN_FLAG).Index(9);
            Map(it => it.CHINA_SCE_FLAG).Index(10);
            Map(it => it.TPE_FLAG).Index(11);
            Map(it => it.ILLG_DISH_FLAG).Index(12);
            Map(it => it.SPCL_ECORE_ENTP_FLAG).Index(13);
            Map(it => it.AGRO_FLAG).Index(14);
            Map(it => it.ARAAF_ENTP_FLAG).Index(15);
            Map(it => it.EU_ORG_FLAG).Index(16);
            Map(it => it.SATI_ENTP_FLAG).Index(17);
            Map(it => it.FNC_PVRT_FLAG).Index(18);
            Map(it => it.UNIC_ENTP_FLAG).Index(19);
            Map(it => it.DEL_FLAG).Index(20);
            Map(it => it.CRTR_TLR_REFNO).Index(21);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(22);
            Map(it => it.CRT_DTTM).Index(23).Convert(it => DateTimeConverter(it.Row, 23, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(24).Convert(it => DateTimeConverter(it.Row, 24, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(25);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(26);
            Map(it => it.LAST_MNT_STS_CODE).Index(27);
            Map(it => it.LAST_MOD_DTTM).Index(28).Convert(it => DateTimeConverter(it.Row, 28, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(29);
            Map(it => it.RCRD_CLNUP_STSCD).Index(30);

        }
    }
}
