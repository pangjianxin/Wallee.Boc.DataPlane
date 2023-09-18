using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicCustomerTypeJob : TDcmpAsyncBackgroundJob<LoadCcicCustomerTypeJobArgs>, ITransientDependency
    {
        private readonly ICcicCustomerTypeRepository _ccicCustomerTypeRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicCustomerTypeJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ITDcmpWorkFlowRepository repository,
            IConfiguration config,
            ICcicCustomerTypeRepository ccicCustomerTypeRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicCustomerTypeRepository = ccicCustomerTypeRepository;
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }
        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicCustomerTypeJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);

            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicCustomerTypeFileName);

                await UpsertAsync(stream, _ccicCustomerTypeRepository, typeof(CcicCustomerTypeMap));

                await _tDcmpWorkFlowManager.NotifyCcicCustomerTypeCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicCustomerTypeMap : ClassMapBase<CcicCustomerType>
    {
        public CcicCustomerTypeMap()
        {

            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.CUS_TP).Index(2);
            Map(it => it.CUS_SUBTP).Index(3);
            Map(it => it.INDCL).Index(4);
            Map(it => it.FAIRS_CUS_CTGY).Index(5);
            Map(it => it.SPV_CUS_TP).Index(6);
            Map(it => it.SOD_ADIV_GOVT_UNIQ).Index(7);
            Map(it => it.CRERU_TYPE_CODE).Index(8);
            Map(it => it.NEW_MODE_CUS_IDR).Index(9);
            Map(it => it.HOSP_CUS_CHAR_CTGY).Index(10);
            Map(it => it.ED_IDY_CUS_CHAR_CTGY).Index(11);
            Map(it => it.ED_IDY_CUS_CTGY).Index(12);
            Map(it => it.CUS_CTGY_LCL).Index(13);
            Map(it => it.CUS_CTGY_STS).Index(14);
            Map(it => it.CUS_BLG_LINE).Index(15);
            Map(it => it.CUS_ORG).Index(16);
            Map(it => it.LWRS_FACT_OF_CMRC_ORG_TP_NAME).Index(17);
            Map(it => it.SPLMT_CUS_TP_RSK_CLBR).Index(18);
            Map(it => it.PPPC_CUS_LEVEL_CODE).Index(19);
            Map(it => it.HEAL_CUS_TP).Index(20);
            Map(it => it.CUS_LYR).Index(21);
            Map(it => it.CUS_SRC).Index(22);
            Map(it => it.CUS_LYLT).Index(23);
            Map(it => it.AVY_SCOR).Index(24);
            Map(it => it.REQ_PRVD_FNRPT_FRQC_CODE).Index(25);
            Map(it => it.CUS_LGCLS_CODE).Index(26);
            Map(it => it.DEL_FLAG).Index(27);
            Map(it => it.CRTR_TLR_REFNO).Index(28);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(29);
            Map(it => it.CRT_DTTM).Index(30).Convert(it => DateTimeConverter(it.Row, 30, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(31).Convert(it => DateTimeConverter(it.Row, 31, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(32);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(33);
            Map(it => it.LAST_MNT_STS_CODE).Index(34);
            Map(it => it.LAST_MOD_DTTM).Index(35).Convert(it => DateTimeConverter(it.Row, 35, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(36);
            Map(it => it.RCRD_CLNUP_STSCD).Index(37);
        }
    }
}

