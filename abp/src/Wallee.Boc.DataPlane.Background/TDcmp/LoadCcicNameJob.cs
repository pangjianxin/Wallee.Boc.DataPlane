using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicNameJob : TDcmpAsyncBackgroundJob<LoadCcicNameJobArgs>, ITransientDependency
    {
        private readonly ICcicNameRepository _ccicNameRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicNameJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicNameRepository ccicNameRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicNameRepository = ccicNameRepository;
            _tDcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicNameJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicNameFileName);

                await UpsertAsync(stream, _ccicNameRepository, typeof(CcicNameMap));

                await _tDcmpWorkFlowManager.NotifyCcicNameCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicNameMap : ClassMap<CcicName>
    {
        public CcicNameMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.CUS_NAME_LANG).Index(1);
            Map(it => it.LGPER_CODE).Index(2);
            Map(it => it.CUS_NAME).Index(3);
            Map(it => it.CUS_NAME_START_DT).Index(4).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_NAME_TMT_DT).Index(5).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SHTNM).Index(6);
            Map(it => it.CUS_SHTNM_START_DT).Index(7).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SHTNM_ENDDT_PERI).Index(8).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SWIFT_NAME).Index(9);
            Map(it => it.CUS_SWIFT_NAME_START_DT).Index(10).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SWIFT_NAME_ENDDT_PERI).Index(11).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SHNM).Index(12);
            Map(it => it.CUS_SHNM_START_DT).Index(13).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_SHNM_ENDDT_PERI).Index(14).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_FRMNM_NAME).Index(15);
            Map(it => it.CUS_FRMNM_NAME_START_DT).Index(16).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_FRMNM_NAME_ENDDT_PERI).Index(17).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_OTHR_NAME_TP).Index(18);
            Map(it => it.CUS_OTHR_NAME).Index(19);
            Map(it => it.CUS_OTHR_NAME_START_DT).Index(20).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.CUS_OTHR_NAME_TMT_DT).Index(21).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
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
