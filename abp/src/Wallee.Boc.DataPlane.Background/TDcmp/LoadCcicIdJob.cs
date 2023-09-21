using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicIdJob : CcicCusInfoAsyncBackgroundJob<LoadCcicIdJobArgs>, ITransientDependency
    {
        private readonly ICcicIdRepository _ccicIdRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicIdJob(IOptions<FtpOptions> ftpOptions, IClock clock, ICcicCusInfoWorkFlowRepository repository,
            IConfiguration config,
            ICcicIdRepository ccicIdRepository,
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicIdRepository = ccicIdRepository;
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicIdJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicIdFileName);

                await UpsertAsync(stream, _ccicIdRepository, typeof(CcicIdMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicIdCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicIdMap : ClassMap<CcicId>
    {
        public CcicIdMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.CRDT_TP).Index(1);
            Map(it => it.CRDT_SN).Index(2);
            Map(it => it.LGPER_CODE).Index(3);
            Map(it => it.CRAD).Index(4);
            Map(it => it.CRDT_ATR).Index(5);
            Map(it => it.OTHR_CRTY_NOTE).Index(6);
            Map(it => it.CRDT_SGIS_ADDR4).Index(7);
            Map(it => it.ISSCT_AHR_LO).Index(8);
            Map(it => it.CRDT_SGIS_AHR_NAME).Index(9);
            Map(it => it.CRDT_SGIS_DT).Index(10).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CRDT_EXP_DT).Index(11).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CRDT_PRM_VLD_FLAG).Index(12);
            Map(it => it.ANINS_DT).Index(13).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CRDT_IMAGE_ID).Index(14);
            Map(it => it.ID_INF_DES).Index(15);
            Map(it => it.CRDT_STS).Index(16);
            Map(it => it.DEL_FLAG).Index(17);
            Map(it => it.CRTR_TLR_REFNO).Index(18);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(19);
            Map(it => it.CRT_DTTM).Index(20).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(21).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(22);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(23);
            Map(it => it.LAST_MNT_STS_CODE).Index(24);
            Map(it => it.LAST_MOD_DTTM).Index(25).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(26);
            Map(it => it.RCRD_CLNUP_STSCD).Index(27);
        }
    }
}
