using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;

public class CcicNameRepository : EfCoreRepository<DataPlaneDbContext, CcicName>, ICcicNameRepository
{
    public CcicNameRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicName> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
         .On(it => new { it.CUSNO, it.CUS_NAME_LANG, it.LGPER_CODE })
         .WhenMatched((origin, cur) => new CcicName
         {
             CUSNO = cur.CUSNO,
             CUS_NAME_LANG = cur.CUS_NAME_LANG,
             LGPER_CODE = cur.LGPER_CODE,
             CUS_NAME = cur.CUS_NAME,
             CUS_NAME_START_DT = cur.CUS_NAME_START_DT,
             CUS_NAME_TMT_DT = cur.CUS_NAME_TMT_DT,
             CUS_SHTNM = cur.CUS_SHTNM,
             CUS_SHTNM_START_DT = cur.CUS_SHTNM_START_DT,
             CUS_SHTNM_ENDDT_PERI = cur.CUS_SHTNM_ENDDT_PERI,
             CUS_SWIFT_NAME = cur.CUS_SWIFT_NAME,
             CUS_SWIFT_NAME_START_DT = cur.CUS_SWIFT_NAME_START_DT,
             CUS_SWIFT_NAME_ENDDT_PERI = cur.CUS_SWIFT_NAME_ENDDT_PERI,
             CUS_SHNM = cur.CUS_SHNM,
             CUS_SHNM_START_DT = cur.CUS_SHNM_START_DT,
             CUS_SHNM_ENDDT_PERI = cur.CUS_SHNM_ENDDT_PERI,
             CUS_FRMNM_NAME = cur.CUS_FRMNM_NAME,
             CUS_FRMNM_NAME_START_DT = cur.CUS_FRMNM_NAME_START_DT,
             CUS_FRMNM_NAME_ENDDT_PERI = cur.CUS_FRMNM_NAME_ENDDT_PERI,
             CUS_OTHR_NAME_TP = cur.CUS_OTHR_NAME_TP,
             CUS_OTHR_NAME = cur.CUS_OTHR_NAME,
             CUS_OTHR_NAME_START_DT = cur.CUS_OTHR_NAME_START_DT,
             CUS_OTHR_NAME_TMT_DT = cur.CUS_OTHR_NAME_TMT_DT,
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

    public override async Task<IQueryable<CcicName>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}