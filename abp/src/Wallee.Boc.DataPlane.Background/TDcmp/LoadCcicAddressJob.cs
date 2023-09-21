using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.CsvHelper;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicAddressJob : TDcmpAsyncBackgroundJob<LoadCcicAddressJobArgs>, ITransientDependency
    {
        private readonly ICcicAddressRepository _ccicAddressRepository;
        private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

        public LoadCcicAddressJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ITDcmpWorkFlowRepository repository,
            ICcicAddressRepository ccicAddressRepository,
            TDcmpWorkFlowManager tDcmpWorkFlowManager,
            IConfiguration config) : base(ftpOptions, clock, repository, config)
        {
            _ccicAddressRepository = ccicAddressRepository;
            _tDcmpWorkFlowManager = tDcmpWorkFlowManager;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(LoadCcicAddressJobArgs args)
        {
            var workFlow = await Repository.GetAsync(args.WorkFlowId);

            try
            {
                using var stream = await GetStreamFromFtp(workFlow, FtpOptions.CcicAddressFileName);

                await UpsertAsync(stream, _ccicAddressRepository, typeof(CcicAddressMap));

                await _tDcmpWorkFlowManager.NotifyCcicAddressCompletedAsync(workFlow);

                await Repository.UpdateAsync(workFlow);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(workFlow, ex);
                throw;
            }
        }
    }

    internal class CcicAddressMap : ClassMap<CcicAddress>
    {
        public CcicAddressMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.ADDR_TP).Index(1);
            Map(it => it.ADDR_SN).Index(2);
            Map(it => it.LGPER_CODE).Index(3);
            Map(it => it.ADDR_LANG).Index(4);
            Map(it => it.CNRG).Index(5);
            Map(it => it.PRVC_MNCP).Index(6);
            Map(it => it.CITY).Index(7);
            Map(it => it.CNTY).Index(8);
            Map(it => it.ADDR1).Index(9);
            Map(it => it.PSALC).Index(10);
            Map(it => it.RTNPT_FLAG).Index(11);
            Map(it => it.PS_NAME).Index(12);
            Map(it => it.CTY_LNG_CODE).Index(13);
            Map(it => it.CTY_RGON_RSK_GRD_CODE).Index(14);
            Map(it => it.RLTV_UNNPY_URBN_CODE).Index(15);
            Map(it => it.BKCD_URBN_CODE).Index(16);
            Map(it => it.REL_TP_CODE).Index(17);
            Map(it => it.REL_STRT_DT).Index(18).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.REL_END_DT).Index(19).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd"));
            Map(it => it.REL_STRT_TIME).Index(20);
            Map(it => it.REL_END_TIME).Index(21);
            Map(it => it.REL_DES).Index(22);
            Map(it => it.DEL_FLAG).Index(23);
            Map(it => it.CRTR_TLR_REFNO).Index(24);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(25);
            Map(it => it.CRT_DTTM).Index(26).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(27).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(28);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(29);
            Map(it => it.LAST_MNT_STS_CODE).Index(30);
            Map(it => it.LAST_MOD_DTTM).Index(31).TypeConverter(new ReadingDateTimeConverter("yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(32);
            Map(it => it.RCRD_CLNUP_STSCD).Index(33);
        }


    }
}
