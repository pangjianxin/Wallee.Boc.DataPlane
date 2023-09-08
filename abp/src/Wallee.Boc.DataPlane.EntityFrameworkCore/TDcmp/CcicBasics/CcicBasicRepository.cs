using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;

public class CcicBasicRepository : EfCoreRepository<DataPlaneDbContext, CcicBasic>, ICcicBasicRepository
{
    public CcicBasicRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicBasic>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    public async Task UpsertAsync(IEnumerable<CcicBasic> list)
    {
        await (await GetDbSetAsync()).UpsertRange(list)
            .On(it => new { it.CUSNO, it.LGPER_CODE })
            .WhenMatched((origin, cur) => new CcicBasic
            {
                CUSNO = cur.CUSNO,
                LGPER_CODE = cur.LGPER_CODE,
                AL_CODE = cur.AL_CODE,
                COMM_LNG = cur.COMM_LNG,
                CUSRL_TE_CHNL = cur.CUSRL_TE_CHNL,
                CSMGR_TLR_REFNO = cur.CSMGR_TLR_REFNO,
                OPNAC_ORG_REFNO = cur.OPNAC_ORG_REFNO,
                BLG_ORG_REFNO = cur.BLG_ORG_REFNO,
                OPNAC_DT = cur.OPNAC_DT,
                CLS_DT = cur.CLS_DT,
                LAST_CNMDT_PERI = cur.LAST_CNMDT_PERI,
                CSTST = cur.CSTST,
                DSABL_REASN = cur.DSABL_REASN,
                DSABL_REASN_NOTE = cur.DSABL_REASN_NOTE,
                PART_RL_TP_CODE = cur.PART_RL_TP_CODE,
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
}