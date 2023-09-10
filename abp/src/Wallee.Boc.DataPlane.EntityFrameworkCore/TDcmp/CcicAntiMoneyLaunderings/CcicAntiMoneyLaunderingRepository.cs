using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;

public class CcicAntiMoneyLaunderingRepository : EfCoreRepository<DataPlaneDbContext, CcicAntiMoneyLaundering>, ICcicAntiMoneyLaunderingRepository
{
    public CcicAntiMoneyLaunderingRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicAntiMoneyLaundering> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
            .On(it => new { it.CUSNO, it.AML_INF_SN, it.LGPER_CODE })
            .WhenMatched((origin, cur) => new CcicAntiMoneyLaundering
            {
                CUSNO = cur.CUSNO,
                AML_INF_SN = cur.AML_INF_SN,
                LGPER_CODE = cur.LGPER_CODE,
                EXPC_MO_TXN_SZ_AMT = cur.EXPC_MO_TXN_SZ_AMT,
                EXPC_MO_TXN_SZ_CUR = cur.EXPC_MO_TXN_SZ_CUR,
                CRRCUS_CODE = cur.CRRCUS_CODE,
                SDD_CUS_TP = cur.SDD_CUS_TP,
                TE_CUSRL_PPS = cur.TE_CUSRL_PPS,
                PURPOSE_REMARK = cur.PURPOSE_REMARK,
                BENEO_ID_INFO = cur.BENEO_ID_INFO,
                CANNO_ID_BENEO_REASN = cur.CANNO_ID_BENEO_REASN,
                EXST_EXT_SANCT_NMLST_FLAG = cur.EXST_EXT_SANCT_NMLST_FLAG,
                POLI_FLAG = cur.POLI_FLAG,
                CRR_RSK_GRD_CODE = cur.CRR_RSK_GRD_CODE,
                AML_RSK_GRD_VLD_START_DT = cur.AML_RSK_GRD_VLD_START_DT,
                AML_RSK_GRD_VLD_TMT_DT = cur.AML_RSK_GRD_VLD_TMT_DT,
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

    public override async Task<IQueryable<CcicAntiMoneyLaundering>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}