﻿using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicBasicJob : CcicCusInfoAsyncBackgroundJob<LoadCcicBasicJobArgs>, ITransientDependency
    {
        private readonly ICcicBasicRepository _ccicBasicRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicBasicJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ICcicCusInfoWorkFlowRepository repository,
            ICcicBasicRepository ccicBasicRepository,
            CcicCusInfoWorkFlowManager tDcmpWorkFlowManager,
            IConfiguration config) : base(ftpOptions, clock, repository, config)
        {
            _ccicBasicRepository = ccicBasicRepository;
            _ccicCusInfoWorkFlowManager = tDcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicBasicJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);

            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicBasicFileName);

                await UpsertAsync(stream, _ccicBasicRepository, typeof(CcicBasicMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicBasicCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }

    }

    internal class CcicBasicMap : ClassMap<CcicBasic>
    {
        public CcicBasicMap()
        {
            Map(m => m.CUSNO).Index(0);
            Map(m => m.LGPER_CODE).Index(1);
            Map(m => m.AL_CODE).Index(2);
            Map(m => m.COMM_LNG).Index(3);
            Map(m => m.CUSRL_TE_CHNL).Index(4);
            Map(m => m.CSMGR_TLR_REFNO).Index(5);
            Map(m => m.OPNAC_ORG_REFNO).Index(6);
            Map(m => m.BLG_ORG_REFNO).Index(7);
            Map(m => m.OPNAC_DT).Index(8).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(m => m.CLS_DT).Index(9).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(m => m.LAST_CNMDT_PERI).Index(10).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(m => m.CSTST).Index(11);
            Map(m => m.DSABL_REASN).Index(12);
            Map(m => m.DSABL_REASN_NOTE).Index(13);
            Map(m => m.PART_RL_TP_CODE).Index(14);
            Map(m => m.DEL_FLAG).Index(15);
            Map(m => m.CRTR_TLR_REFNO).Index(16);
            Map(m => m.CRT_TLR_ORG_REFNO).Index(17);
            Map(m => m.CRT_DTTM).Index(18).Validate(it => !string.IsNullOrEmpty(it.Field)).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(m => m.CUR_ACDT_PERI).Index(19).Validate(it => !string.IsNullOrEmpty(it.Field)).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(m => m.LTST_MOD_TLR_REFNO).Index(20);
            Map(m => m.MOD_TLR_ORG_REFNO).Index(21);
            Map(m => m.LAST_MNT_STS_CODE).Index(22);
            Map(m => m.LAST_MOD_DTTM).Index(23).Validate(it => !string.IsNullOrEmpty(it.Field)).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(m => m.RCRD_VRSN_SN).Index(24);
            Map(m => m.RCRD_CLNUP_STSCD).Index(25);
        }
    }
}
