using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;

public class CcicLsolationListRepository : EfCoreRepository<DataPlaneDbContext, CcicLsolationList>, ICcicLsolationListRepository
{
    public CcicLsolationListRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicLsolationList> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
        .On(it => new { it.CUSNO, it.LGPER_CODE })
        .WhenMatched((origin, cur) => new CcicLsolationList
        {
            CUSNO = cur.CUSNO,
            LGPER_CODE = cur.LGPER_CODE,
            QUARN_STS = cur.QUARN_STS,
            QUARN_TP = cur.QUARN_TP,
            QUARN_REASN = cur.QUARN_REASN,
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

    public override async Task<IQueryable<CcicLsolationList>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}