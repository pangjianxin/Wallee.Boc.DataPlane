﻿using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicGeneralOrgJob : CcicCusInfoAsyncBackgroundJob<LoadCcicGeneralOrgJobArgs>, ITransientDependency
    {
        private readonly ICcicGeneralOrgRepository _ccicGeneralOrgRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicGeneralOrgJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ICcicCusInfoWorkFlowRepository repository,
            IConfiguration config,
            ICcicGeneralOrgRepository ccicGeneralOrgRepository,
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicGeneralOrgRepository = ccicGeneralOrgRepository;
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicGeneralOrgJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicGeneralOrgFileName);

                await UpsertAsync(stream, _ccicGeneralOrgRepository, typeof(CcicGeneralOrgMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicGeneralOrgCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicGeneralOrgMap : ClassMap<CcicGeneralOrg>
    {
        public CcicGeneralOrgMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.LGPER_CODE).Index(1);
            Map(it => it.ENJ_LCL_GOVT_PRFT_PC_TP).Index(2);
            Map(it => it.FNC_SUBS_INCM_SRC).Index(3);
            Map(it => it.FNDS_SRC_INF).Index(4);
            Map(it => it.WLTH_SRC_OVSEA).Index(5);
            Map(it => it.WLTH_SRC_IS_OTHR_HOUR_NOTE).Index(6);
            Map(it => it.WLTH_SRC_CNRG).Index(7);
            Map(it => it.ENTP_INTD).Index(8);
            Map(it => it.LOGO_IMAGE_FILE_ID).Index(9);
            Map(it => it.LOGO_NAME).Index(10);
            Map(it => it.CO_TAOA_ATTCH_ID).Index(11);
            Map(it => it.EXST_OURBK_EQU_PCT).Index(12);
            Map(it => it.BSC_DEP_ACCNO).Index(13);
            Map(it => it.BSC_DEP_ACC_ACOP_APVL_NO).Index(14);
            Map(it => it.BSC_DEP_ACC_DEPBK_NAME).Index(15);
            Map(it => it.BSC_DEP_ACC_OPNAC_DT).Index(16).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.ENTP_DEVE_STRTG).Index(17);
            Map(it => it.DEL_FLAG).Index(18);
            Map(it => it.CRTR_TLR_REFNO).Index(19);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(20);
            Map(it => it.CRT_DTTM).Index(21).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(22).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(23);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(24);
            Map(it => it.LAST_MNT_STS_CODE).Index(25);
            Map(it => it.LAST_MOD_DTTM).Index(26).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(27);
            Map(it => it.RCRD_CLNUP_STSCD).Index(28);
        }
    }
}
