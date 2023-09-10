using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;

public class CcicIdRepository : EfCoreRepository<DataPlaneDbContext, CcicId>, ICcicIdRepository
{
    public CcicIdRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicId> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
         .On(it => new { it.CUSNO, it.CRDT_TP, it.CRDT_SN, it.LGPER_CODE })
         .WhenMatched((origin, cur) => new CcicId
         {
             CUSNO = cur.CUSNO,
             CRDT_TP = cur.CRDT_TP,
             CRDT_SN = cur.CRDT_SN,
             LGPER_CODE = cur.LGPER_CODE,
             CRAD = cur.CRAD,
             CRDT_ATR = cur.CRDT_ATR,
             OTHR_CRTY_NOTE = cur.OTHR_CRTY_NOTE,
             CRDT_SGIS_ADDR4 = cur.CRDT_SGIS_ADDR4,
             ISSCT_AHR_LO = cur.ISSCT_AHR_LO,
             CRDT_SGIS_AHR_NAME = cur.CRDT_SGIS_AHR_NAME,
             CRDT_SGIS_DT = cur.CRDT_SGIS_DT,
             CRDT_EXP_DT = cur.CRDT_EXP_DT,
             CRDT_PRM_VLD_FLAG = cur.CRDT_PRM_VLD_FLAG,
             ANINS_DT = cur.ANINS_DT,
             CRDT_IMAGE_ID = cur.CRDT_IMAGE_ID,
             ID_INF_DES = cur.ID_INF_DES,
             CRDT_STS = cur.CRDT_STS,
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

    public override async Task<IQueryable<CcicId>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}