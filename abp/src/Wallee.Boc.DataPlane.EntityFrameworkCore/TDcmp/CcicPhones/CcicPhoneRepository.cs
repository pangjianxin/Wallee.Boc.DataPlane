using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;

public class CcicPhoneRepository : EfCoreRepository<DataPlaneDbContext, CcicPhone>, ICcicPhoneRepository
{
    public CcicPhoneRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicPhone> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
          .On(it => new { it.CUSNO, it.UNIT_TEL_TP, it.CNTEL_SN, it.LGPER_CODE })
          .WhenMatched((origin, cur) => new CcicPhone
          {
              CUSNO = cur.CUSNO,
              UNIT_TEL_TP = cur.UNIT_TEL_TP,
              CNTEL_SN = cur.CNTEL_SN,
              LGPER_CODE = cur.LGPER_CODE,
              IC = cur.IC,
              DMST_ARCD = cur.DMST_ARCD,
              EXN_NO = cur.EXN_NO,
              TEL_NO = cur.TEL_NO,
              ADDR_TP = cur.ADDR_TP,
              ELC_ADTP = cur.ELC_ADTP,
              REL_TP_CODE = cur.REL_TP_CODE,
              REL_STRT_DT = cur.REL_STRT_DT,
              REL_END_DT = cur.REL_END_DT,
              REL_STRT_TIME = cur.REL_STRT_TIME,
              REL_END_TIME = cur.REL_END_TIME,
              REL_DES = cur.REL_DES,
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

    public override async Task<IQueryable<CcicPhone>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}