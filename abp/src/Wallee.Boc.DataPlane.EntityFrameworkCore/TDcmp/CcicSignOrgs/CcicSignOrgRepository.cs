using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

public class CcicSignOrgRepository : EfCoreRepository<DataPlaneDbContext, CcicSignOrg>, ICcicSignOrgRepository
{
    public CcicSignOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicSignOrg> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
       .On(it => new { it.CUSNO, it.LGPER_CODE })
       .WhenMatched((origin, cur) => new CcicSignOrg
       {
           CUSNO = cur.CUSNO,
           LGPER_CODE = cur.LGPER_CODE,
           SUPR_UNIT_LGPER_PNP_TP = cur.SUPR_UNIT_LGPER_PNP_TP,
           LSTCO_FLAG = cur.LSTCO_FLAG,
           HTCHE_FLAG = cur.HTCHE_FLAG,
           EXMPT_RGS_SOC_GROU_FLAG = cur.EXMPT_RGS_SOC_GROU_FLAG,
           NON_PFT_PROP_ORG_FLAG = cur.NON_PFT_PROP_ORG_FLAG,
           SERIS_ILLG_RCRD_FLAG = cur.SERIS_ILLG_RCRD_FLAG,
           PS_LIT_FTA_WITH_FLAG = cur.PS_LIT_FTA_WITH_FLAG,
           PUBEN_FLAG = cur.PUBEN_FLAG,
           CHINA_SCE_FLAG = cur.CHINA_SCE_FLAG,
           TPE_FLAG = cur.TPE_FLAG,
           ILLG_DISH_FLAG = cur.ILLG_DISH_FLAG,
           SPCL_ECORE_ENTP_FLAG = cur.SPCL_ECORE_ENTP_FLAG,
           AGRO_FLAG = cur.AGRO_FLAG,
           ARAAF_ENTP_FLAG = cur.ARAAF_ENTP_FLAG,
           EU_ORG_FLAG = cur.EU_ORG_FLAG,
           SATI_ENTP_FLAG = cur.SATI_ENTP_FLAG,
           FNC_PVRT_FLAG = cur.FNC_PVRT_FLAG,
           UNIC_ENTP_FLAG = cur.UNIC_ENTP_FLAG,
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

    public override async Task<IQueryable<CcicSignOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}