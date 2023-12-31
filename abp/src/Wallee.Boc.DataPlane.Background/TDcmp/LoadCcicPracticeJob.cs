﻿using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicPracticeJob : CcicCusInfoAsyncBackgroundJob<LoadCcicPracticeJobArgs>, ITransientDependency
    {
        private readonly ICcicPracticeRepository _ccicPracticeRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicPracticeJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ICcicCusInfoWorkFlowRepository repository, IConfiguration config,
            ICcicPracticeRepository ccicPracticeRepository,
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicPracticeRepository = ccicPracticeRepository;
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicPracticeJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicPracticeFileName);

                await UpsertAsync(stream, _ccicPracticeRepository, typeof(CcicPracticeMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicPracticeCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicPracticeMap : ClassMap<CcicPractice>
    {
        public CcicPracticeMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.OPRT_INF_SN).Index(1);
            Map(it => it.LGPER_CODE).Index(2);
            Map(it => it.OPRT_INFO_STAT_YR).Index(3);
            Map(it => it.OPRT_INFO_STAT_INST).Index(4);
            Map(it => it.ENTP_GRWUP_STG_CODE).Index(5);
            Map(it => it.ENTP_OPRT_STS).Index(6);
            Map(it => it.CUS_OPRT_STS_START_DT).Index(7).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_OPRT_STS_TMT_DT).Index(8).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.INFO_OVW).Index(9);
            Map(it => it.CROSS_IDY_OPRT_FLAG).Index(10);
            Map(it => it.LEAD_PD_AND_BRND_DES).Index(11);
            Map(it => it.BRND_VAL_CUR).Index(12);
            Map(it => it.BRND_VAL).Index(13);
            Map(it => it.BRND_VISI).Index(14);
            Map(it => it.BRND_VISI_SURVY_ORG_NAME).Index(15);
            Map(it => it.ENTP_PD_LIFE_CYCLE).Index(16);
            Map(it => it.CMRC_AVY_PEAK_IDR).Index(17);
            Map(it => it.MAIN_ORI_MTRL_DES).Index(18);
            Map(it => it.CRER_PNUM).Index(19);
            Map(it => it.CO_EMPE_AVGAG).Index(20);
            Map(it => it.SALES_CUR).Index(21);
            Map(it => it.SALES_AMT).Index(22);
            Map(it => it.AST_TAMT_CUR).Index(23);
            Map(it => it.AST_TAMT).Index(24);
            Map(it => it.NTAST_CUR).Index(25);
            Map(it => it.NTAST_AMT).Index(26);
            Map(it => it.DEL_FLAG).Index(27);
            Map(it => it.CRTR_TLR_REFNO).Index(28);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(29);
            Map(it => it.CRT_DTTM).Index(30).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(31).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(32);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(33);
            Map(it => it.LAST_MNT_STS_CODE).Index(34);
            Map(it => it.LAST_MOD_DTTM).Index(35).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(36);
            Map(it => it.RCRD_CLNUP_STSCD).Index(37);

        }
    }
}
