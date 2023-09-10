using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;

public class CcicPracticeRepository : EfCoreRepository<DataPlaneDbContext, CcicPractice>, ICcicPracticeRepository
{
    public CcicPracticeRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicPractice> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
        .On(it => new { it.CUSNO, it.OPRT_INF_SN, it.LGPER_CODE })
        .WhenMatched((origin, cur) => new CcicPractice
        {
            CUSNO = cur.CUSNO,
            OPRT_INF_SN = cur.OPRT_INF_SN,
            LGPER_CODE = cur.LGPER_CODE,
            OPRT_INFO_STAT_YR = cur.OPRT_INFO_STAT_YR,
            OPRT_INFO_STAT_INST = cur.OPRT_INFO_STAT_INST,
            ENTP_GRWUP_STG_CODE = cur.ENTP_GRWUP_STG_CODE,
            ENTP_OPRT_STS = cur.ENTP_OPRT_STS,
            CUS_OPRT_STS_START_DT = cur.CUS_OPRT_STS_START_DT,
            CUS_OPRT_STS_TMT_DT = cur.CUS_OPRT_STS_TMT_DT,
            INFO_OVW = cur.INFO_OVW,
            CROSS_IDY_OPRT_FLAG = cur.CROSS_IDY_OPRT_FLAG,
            LEAD_PD_AND_BRND_DES = cur.LEAD_PD_AND_BRND_DES,
            BRND_VAL_CUR = cur.BRND_VAL_CUR,
            BRND_VAL = cur.BRND_VAL,
            BRND_VISI = cur.BRND_VISI,
            BRND_VISI_SURVY_ORG_NAME = cur.BRND_VISI_SURVY_ORG_NAME,
            ENTP_PD_LIFE_CYCLE = cur.ENTP_PD_LIFE_CYCLE,
            CMRC_AVY_PEAK_IDR = cur.CMRC_AVY_PEAK_IDR,
            MAIN_ORI_MTRL_DES = cur.MAIN_ORI_MTRL_DES,
            CRER_PNUM = cur.CRER_PNUM,
            CO_EMPE_AVGAG = cur.CO_EMPE_AVGAG,
            SALES_CUR = cur.SALES_CUR,
            SALES_AMT = cur.SALES_AMT,
            AST_TAMT_CUR = cur.AST_TAMT_CUR,
            AST_TAMT = cur.AST_TAMT,
            NTAST_CUR = cur.NTAST_CUR,
            NTAST_AMT = cur.NTAST_AMT,
            DEL_FLAG = cur.DEL_FLAG,
            CRTR_TLR_REFNO = cur.CRTR_TLR_REFNO,
            CRT_TLR_ORG_REFNO = cur.CRT_TLR_ORG_REFNO,
            CRT_DTTM = cur.CRT_DTTM,
            CUR_ACDT_PERI = cur.CUR_ACDT_PERI,
            LTST_MOD_TLR_REFNO = cur.LTST_MOD_TLR_REFNO,
            MOD_TLR_ORG_REFNO = cur.MOD_TLR_ORG_REFNO,
            LAST_MNT_STS_CODE = cur.LAST_MNT_STS_CODE,
            LAST_MOD_DTTM = cur.LAST_MOD_DTTM,
            RCRD_VRSN_SN = cur.RCRD_VRSN_SN,
            RCRD_CLNUP_STSCD = cur.RCRD_CLNUP_STSCD
        }).RunAsync();
    }

    public override async Task<IQueryable<CcicPractice>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}