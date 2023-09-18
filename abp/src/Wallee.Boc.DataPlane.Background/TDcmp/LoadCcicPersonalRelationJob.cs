using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicPersonalRelationJob : TDcmpAsyncBackgroundJob<LoadCcicPersonalRelationJobArgs>, ITransientDependency
    {
        private readonly ICcicPersonalRelationRepository _ccicPersonalRelationRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicPersonalRelationJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicPersonalRelationRepository ccicPersonalRelationRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicPersonalRelationRepository = ccicPersonalRelationRepository;
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicPersonalRelationJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicPersonalRelationFileName);

                await UpsertAsync(stream, _ccicPersonalRelationRepository, typeof(CcicPersonalRelationMap));

                await _tDcmpWorkFlowManager.NotifyCcicPersonalRelationCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicPersonalRelationMap : ClassMapBase<CcicPersonalRelation>
    {
        public CcicPersonalRelationMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.REL_RL).Index(1);
            Map(it => it.PRINT_CUSNO_YARD).Index(2);
            Map(it => it.LGPER_CODE).Index(3);
            Map(it => it.REL_DES).Index(4);
            Map(it => it.REL_STRT_DT).Index(5).Convert(it => DateTimeConverter(it.Row, 5, "yyyyMMdd"));
            Map(it => it.REL_END_DT).Index(6).Convert(it => DateTimeConverter(it.Row, 6, "yyyyMMdd"));
            Map(it => it.REL_STRT_TIME).Index(7);
            Map(it => it.REL_END_TIME).Index(8);
            Map(it => it.DEL_FLAG).Index(9);
            Map(it => it.CRTR_TLR_REFNO).Index(10);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(11);
            Map(it => it.CRT_DTTM).Index(12).Convert(it => DateTimeConverter(it.Row, 12, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(13).Convert(it => DateTimeConverter(it.Row, 13, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(14);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(15);
            Map(it => it.LAST_MNT_STS_CODE).Index(16);
            Map(it => it.LAST_MOD_DTTM).Index(17).Convert(it => DateTimeConverter(it.Row, 17, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(18);
            Map(it => it.RCRD_CLNUP_STSCD).Index(19);

        }
    }
}
