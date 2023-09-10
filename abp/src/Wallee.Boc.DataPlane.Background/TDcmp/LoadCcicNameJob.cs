using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.CsvHelper;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicNameJob : TDcmpAsyncBackgroundJob<LoadCcicNameJobArgs>, ITransientDependency
    {
        private readonly ICcicNameRepository _ccicNameRepository;
        private readonly TDcmpWorkFlowManager _dcmpWorkFlowManager;

        public LoadCcicNameJob(IOptions<FtpOptions> ftpOptions, IClock clock,
            ITDcmpWorkFlowRepository repository, IConfiguration config,
            ICcicNameRepository ccicNameRepository,
            TDcmpWorkFlowManager dcmpWorkFlowManager) : base(ftpOptions, clock, repository, config)
        {
            _ccicNameRepository = ccicNameRepository;
            _dcmpWorkFlowManager = dcmpWorkFlowManager;
        }

        public override Task ExecuteAsync(LoadCcicNameJobArgs args)
        {
            throw new NotImplementedException();
        }
    }

    internal class CcicNameMap : ClassMapBase<CcicName>
    {
        public CcicNameMap()
        {
            Map(it => it.CUSNO).Index(0);
            Map(it => it.CUS_NAME_LANG).Index(1);
            Map(it => it.LGPER_CODE).Index(2);
            Map(it => it.CUS_NAME).Index(3);
            Map(it => it.CUS_NAME_START_DT).Index(4).Convert(it => DateTimeConverter(it.Row, 4, "yyyyMMdd"));
            Map(it => it.CUS_NAME_TMT_DT).Index(5).Convert(it => DateTimeConverter(it.Row, 5, "yyyyMMdd"));
            Map(it => it.CUS_SHTNM).Index(6);
            Map(it => it.CUS_SHTNM_START_DT).Index(7).Convert(it => DateTimeConverter(it.Row, 7, "yyyyMMdd"));
            Map(it => it.CUS_SHTNM_ENDDT_PERI).Index(8).Convert(it => DateTimeConverter(it.Row, 8, "yyyyMMdd"));
            Map(it => it.CUS_SWIFT_NAME).Index(9);
            Map(it => it.CUS_SWIFT_NAME_START_DT).Index(10).Convert(it => DateTimeConverter(it.Row, 10, "yyyyMMdd"));
            Map(it => it.CUS_SWIFT_NAME_ENDDT_PERI).Index(11).Convert(it => DateTimeConverter(it.Row, 11, "yyyyMMdd"));
            Map(it => it.CUS_SHNM).Index(12);
            Map(it => it.CUS_SHNM_START_DT).Index(13).Convert(it => DateTimeConverter(it.Row, 13, "yyyyMMdd"));
            Map(it => it.CUS_SHNM_ENDDT_PERI).Index(14).Convert(it => DateTimeConverter(it.Row, 14, "yyyyMMdd"));
            Map(it => it.CUS_FRMNM_NAME).Index(15);
            Map(it => it.CUS_FRMNM_NAME_START_DT).Index(16).Convert(it => DateTimeConverter(it.Row, 16, "yyyyMMdd"));
            Map(it => it.CUS_FRMNM_NAME_ENDDT_PERI).Index(17).Convert(it => DateTimeConverter(it.Row, 17, "yyyyMMdd"));
            Map(it => it.CUS_OTHR_NAME_TP).Index(18);
            Map(it => it.CUS_OTHR_NAME).Index(19);
            Map(it => it.CUS_OTHR_NAME_START_DT).Index(20).Convert(it => DateTimeConverter(it.Row, 20, "yyyyMMdd"));
            Map(it => it.CUS_OTHR_NAME_TMT_DT).Index(21).Convert(it => DateTimeConverter(it.Row, 21, "yyyyMMdd"));
            Map(it => it.DEL_FLAG).Index(22);
            Map(it => it.CRTR_TLR_REFNO).Index(23);
            Map(it => it.CRT_TLR_ORG_REFNO).Index(24);
            Map(it => it.CRT_DTTM).Index(25).Convert(it => DateTimeConverter(it.Row, 25, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.CUR_ACDT_PERI).Index(26).Convert(it => DateTimeConverter(it.Row, 26, "yyyyMMdd"));
            Map(it => it.LTST_MOD_TLR_REFNO).Index(27);
            Map(it => it.MOD_TLR_ORG_REFNO).Index(28);
            Map(it => it.LAST_MNT_STS_CODE).Index(29);
            Map(it => it.LAST_MOD_DTTM).Index(30).Convert(it => DateTimeConverter(it.Row, 30, "yyyyMMdd HH:mm:ss:ff"));
            Map(it => it.RCRD_VRSN_SN).Index(31);
            Map(it => it.RCRD_CLNUP_STSCD).Index(32);
        }
    }
}
