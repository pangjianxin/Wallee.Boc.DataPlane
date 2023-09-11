using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.CsvHelper;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicRegisterJob : TDcmpAsyncBackgroundJob<LoadCcicRegisterJobArgs>, ITransientDependency
    {
        private readonly ICcicRegisterRepository _ccicRegisterRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicRegisterJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicRegisterRepository ccicRegisterRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicRegisterRepository = ccicRegisterRepository;
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicRegisterJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicRegisterFileName);

                await UpsertAsync(stream, _ccicRegisterRepository, typeof(CcicRegisterMap));

                await _tDcmpWorkFlowManager.NotifyCcicRegisterCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicRegisterMap : ClassMapBase<CcicRegister>
    {
        public CcicRegisterMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.RGST_CNRG).Index(2);
            Map(it => it.ENTP_INCDT_PERI).Index(3).Convert(it => DateTimeConverter(it.Row, 3, "yyyyMMdd"));
            Map(it => it.SEAR_DT).Index(4).Convert(it => DateTimeConverter(it.Row, 4, "yyyyMMdd"));
            Map(it => it.LOUT_DT).Index(5).Convert(it => DateTimeConverter(it.Row, 5, "yyyyMMdd"));
            Map(it => it.OPRT_MATU_START_DT).Index(6).Convert(it => DateTimeConverter(it.Row, 6, "yyyyMMdd"));
            Map(it => it.OPRT_MATU_TMT_DT).Index(7).Convert(it => DateTimeConverter(it.Row, 7, "yyyyMMdd"));
            Map(it => it.OPRT_MATU).Index(8);
            Map(it => it.LGPER_FLAG).Index(9);
            Map(it => it.NO_HV_LGPER_QUA_OF_CUS_TP).Index(10);
            Map(it => it.RGCAP_CUR).Index(11);
            Map(it => it.RC_AMT).Index(12);
            Map(it => it.ARCPT_CUR).Index(13);
            Map(it => it.ARCPT_AMT).Index(14);
            Map(it => it.ORGN_FNDS_CUR).Index(15);
            Map(it => it.ORGN_FNDS_AMT).Index(16);
            Map(it => it.FEE_SRC).Index(17);
            Map(it => it.CARE_UNBDG_TP).Index(18);
            Map(it => it.SHR_TOTAL).Index(19);
            Map(it => it.ISSU_EQU_AMT).Index(20);
            Map(it => it.BZSCP).Index(21);
            Map(it => it.BSN_SCOP).Index(22);
            Map(it => it.PRCLN_AND_BSN_SCOP_DES).Index(23);
            Map(it => it.MAINB_1_SCOP_NOTE).Index(24);
            Map(it => it.MAINB_2_SCOP_NOTE).Index(25);
            Map(it => it.MAINB_3_SCOP_NOTE).Index(26);
            Map(it => it.IVS_PRJ_ENTP_INFO_NOTE).Index(27);
            Map(it => it.MIX_SCOP).Index(28);
            Map(it => it.AVY_TRTY).Index(29);
            Map(it => it.HOST_UNIT_NAME).Index(30);
            Map(it => it.BSN_SPVS_UNIT_NAME).Index(31);
            Map(it => it.IDBZ_BSNLC_WORD_NO_NAME).Index(32);
            Map(it => it.IDBZ_BSNLC_COMP_ITFO_DES).Index(33);
            Map(it => it.IDBZ_BSNLC_BZSCP_AND_MOD_DES).Index(34);
            Map(it => it.DEL_FLAG).Index(35);
            Map(it => it.CRTR_TLR_REFNO).Index(36);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(37);
            Map(it => it.CRT_DTTM).Index(38).Convert(it => DateTimeConverter(it.Row, 38, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(39).Convert(it => DateTimeConverter(it.Row, 39, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(40);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(41);
            Map(it => it.LAST_MNT_STS_CODE).Index(42);
            Map(it => it.LAST_MOD_DTTM).Index(43).Convert(it => DateTimeConverter(it.Row, 43, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(44);
            Map(it => it.RCRD_CLNUP_STSCD).Index(45);

        }
    }
}
