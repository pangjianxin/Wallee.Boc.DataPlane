using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;

public class CcicGeneralOrgRepository : EfCoreRepository<DataPlaneDbContext, CcicGeneralOrg>, ICcicGeneralOrgRepository
{
    public CcicGeneralOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicGeneralOrg> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
         .On(it => new { it.CUSNO, it.LGPER_CODE })
         .WhenMatched((origin, cur) => new CcicGeneralOrg
         {
             CUSNO = cur.CUSNO,
             LGPER_CODE = cur.LGPER_CODE,
             ENJ_LCL_GOVT_PRFT_PC_TP = cur.ENJ_LCL_GOVT_PRFT_PC_TP,
             FNC_SUBS_INCM_SRC = cur.FNC_SUBS_INCM_SRC,
             FNDS_SRC_INF = cur.FNDS_SRC_INF,
             WLTH_SRC_OVSEA = cur.WLTH_SRC_OVSEA,
             WLTH_SRC_IS_OTHR_HOUR_NOTE = cur.WLTH_SRC_IS_OTHR_HOUR_NOTE,
             WLTH_SRC_CNRG = cur.WLTH_SRC_CNRG,
             ENTP_INTD = cur.ENTP_INTD,
             LOGO_IMAGE_FILE_ID = cur.LOGO_IMAGE_FILE_ID,
             LOGO_NAME = cur.LOGO_NAME,
             CO_TAOA_ATTCH_ID = cur.CO_TAOA_ATTCH_ID,
             EXST_OURBK_EQU_PCT = cur.EXST_OURBK_EQU_PCT,
             BSC_DEP_ACCNO = cur.BSC_DEP_ACCNO,
             BSC_DEP_ACC_ACOP_APVL_NO = cur.BSC_DEP_ACC_ACOP_APVL_NO,
             BSC_DEP_ACC_DEPBK_NAME = cur.BSC_DEP_ACC_DEPBK_NAME,
             BSC_DEP_ACC_OPNAC_DT = cur.BSC_DEP_ACC_OPNAC_DT,
             ENTP_DEVE_STRTG = cur.ENTP_DEVE_STRTG,
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

    public override async Task<IQueryable<CcicGeneralOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}