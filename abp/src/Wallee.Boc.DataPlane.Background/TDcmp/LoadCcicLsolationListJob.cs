﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.CsvHelper;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicLsolationListJob : TDcmpAsyncBackgroundJob<LoadCcicLsolationListJobArgs>, ITransientDependency
    {
        private readonly ICcicLsolationListRepository _ccicLsolationListRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;
        public LoadCcicLsolationListJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicLsolationListRepository ccicLsolationListRepository,
            TDcmpWorkFlowManager tDcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicLsolationListRepository = ccicLsolationListRepository;
            _tDcmpWorkFlowManager = tDcmpWorkFlowManager;
        }
        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicLsolationListJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                //using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicLsolationListFileName);

                //await UpsertAsync(stream, _ccicLsolationListRepository, typeof(CcicLsolationListMap));

                await _tDcmpWorkFlowManager.NotifyCcicLsolationListCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
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
            Map(it => it.CRT_DTTM).Index(8).Convert(it => DateTimeConverter(it.Row, 8, "yyyyMMdd")!.Value);
            Map(it => it.CUR_ACDT_PERI).Index(9).Convert(it => DateTimeConverter(it.Row, 9, "yyyyMMdd")!.Value);
            Map(it => it.LTST_MOD_TLR_REFNO).Index(10);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(11);
            Map(it => it.LAST_MNT_STS_CODE).Index(12);
            Map(it => it.LAST_MOD_DTTM).Index(13).Convert(it => DateTimeConverter(it.Row, 13, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(14);
            Map(it => it.RCRD_CLNUP_STSCD).Index(15);

        }
    }
}
