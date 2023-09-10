using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;

public class CcicPersonalRelationRepository : EfCoreRepository<DataPlaneDbContext, CcicPersonalRelation>, ICcicPersonalRelationRepository
{
    public CcicPersonalRelationRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicPersonalRelation> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
          .On(it => new { it.CUSNO, it.REL_RL, it.PRINT_CUSNO_YARD, it.LGPER_CODE })
          .WhenMatched((origin, cur) => new CcicPersonalRelation
          {
              CUSNO = cur.CUSNO,
              REL_RL = cur.REL_RL,
              PRINT_CUSNO_YARD = cur.PRINT_CUSNO_YARD,
              LGPER_CODE = cur.LGPER_CODE,
              REL_DES = cur.REL_DES,
              REL_STRT_DT = cur.REL_STRT_DT,
              REL_END_DT = cur.REL_END_DT,
              REL_STRT_TIME = cur.REL_STRT_TIME,
              REL_END_TIME = cur.REL_END_TIME,
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

    public override async Task<IQueryable<CcicPersonalRelation>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}