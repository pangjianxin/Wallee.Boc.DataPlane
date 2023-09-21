using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicPhoneJob : CcicCusInfoAsyncBackgroundJob<LoadCcicPhoneJobArgs>, ITransientDependency
    {
        private readonly ICcicPhoneRepository _ccicPhoneRepository;
        private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

        public LoadCcicPhoneJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ICcicCusInfoWorkFlowRepository repository, IConfiguration config,
            ICcicPhoneRepository ccicPhoneRepository,
            CcicCusInfoWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicPhoneRepository = ccicPhoneRepository;
            _ccicCusInfoWorkFlowManager = dcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicPhoneJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);
            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicPhoneFileName);

                await UpsertAsync(stream, _ccicPhoneRepository, typeof(CcicPhoneMap));

                await _ccicCusInfoWorkFlowManager.NotifyCcicPhoneCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicPhoneMap : ClassMap<CcicPhone>
    {
        public CcicPhoneMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.UNIT_TEL_TP).Index(1);
            Map(it => it.CNTEL_SN).Index(2);
            Map(it => it.LGPER_CODE).Index(3);
            Map(it => it.IC).Index(4);
            Map(it => it.DMST_ARCD).Index(5);
            Map(it => it.EXN_NO).Index(6);
            Map(it => it.TEL_NO).Index(7);
            Map(it => it.ADDR_TP).Index(8);
            Map(it => it.ELC_ADTP).Index(9);
            Map(it => it.REL_TP_CODE).Index(10);
            Map(it => it.REL_STRT_DT).Index(11).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.REL_END_DT).Index(12).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.REL_STRT_TIME).Index(13);
            Map(it => it.REL_END_TIME).Index(14);
            Map(it => it.REL_DES).Index(15);
            Map(it => it.DEL_FLAG).Index(16);
            Map(it => it.CRTR_TLR_REFNO).Index(17);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(18);
            Map(it => it.CRT_DTTM).Index(19).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(20).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(21);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(22);
            Map(it => it.LAST_MNT_STS_CODE).Index(23);
            Map(it => it.LAST_MOD_DTTM).Index(24).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(25);
            Map(it => it.RCRD_CLNUP_STSCD).Index(26);
        }
    }
}
