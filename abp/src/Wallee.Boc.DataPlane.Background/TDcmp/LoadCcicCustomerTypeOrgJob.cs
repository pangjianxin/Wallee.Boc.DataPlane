using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicCustomerTypeOrgJob : CcicCusInfoAsyncBackgroundJob<LoadCcicCustomerTypeOrgJobArgs>, ITransientDependency
    {
        private readonly ICcicCustomerTypeOrgRepository _ccicCustomerTypeOrgRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicCustomerTypeOrgJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ICcicCusInfoWorkFlowRepository repository,
            IConfiguration config,
            ICcicCustomerTypeOrgRepository ccicCustomerTypeOrgRepository,
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicCustomerTypeOrgRepository = ccicCustomerTypeOrgRepository;
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicCustomerTypeOrgJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicCustomerTypeOrgFileName);

                await UpsertAsync(stream, _ccicCustomerTypeOrgRepository, typeof(CcicCustomerTypeOrgMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicCustomerTypeOrgCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicCustomerTypeOrgMap : ClassMap<CcicCustomerTypeOrg>
    {
        public CcicCustomerTypeOrgMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.NTECO_DEPT).Index(2);
            Map(it => it.ENTP_ECN_CMCLF).Index(3);
            Map(it => it.ENTP_CHAR).Index(4);
            Map(it => it.OWS_STC_CODE).Index(5);
            Map(it => it.ENTP_SZ_MOIMI_STD).Index(6);
            Map(it => it.ENTP_SZ_TB_STD).Index(7);
            Map(it => it.ADMN_HIER).Index(8);
            Map(it => it.RESP_ITFO).Index(9);
            Map(it => it.NONL_SUFLT_ORG_FLAG).Index(10);
            Map(it => it.YES_SUPR_LGPER_OR_SPVS_UNIT_FLAG).Index(11);
            Map(it => it.GOVT_FUNC_TP_GOVT_UNIQ).Index(12);
            Map(it => it.ENV_AND_SOC_RSK_CTGY).Index(13);
            Map(it => it.SEI_TP_CODE).Index(14);
            Map(it => it.HOSP_CUS_LEVEL).Index(15);
            Map(it => it.ORG_TP_CODE).Index(16);
            Map(it => it.IDY_REFNO).Index(17);
            Map(it => it.ORG_TYPE_TAX).Index(18);
            Map(it => it.RSDNT_TAX_IDR).Index(19);
            Map(it => it.ORG_TAX_RSDNT_IDNT_TP).Index(20);
            Map(it => it.TAX_MNT_EFF_DT).Index(21).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.DEL_FLAG).Index(22);
            Map(it => it.CRTR_TLR_REFNO).Index(23);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(24);
            Map(it => it.CRT_DTTM).Index(25).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(26).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(27);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(28);
            Map(it => it.LAST_MNT_STS_CODE).Index(29);
            Map(it => it.LAST_MOD_DTTM).Index(30).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(31);
            Map(it => it.RCRD_CLNUP_STSCD).Index(32);
        }
    }
}
