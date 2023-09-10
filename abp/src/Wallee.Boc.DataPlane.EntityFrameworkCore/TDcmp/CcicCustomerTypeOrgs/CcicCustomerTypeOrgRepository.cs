using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;

public class CcicCustomerTypeOrgRepository : EfCoreRepository<DataPlaneDbContext, CcicCustomerTypeOrg>, ICcicCustomerTypeOrgRepository
{
    public CcicCustomerTypeOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicCustomerTypeOrg> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
          .On(it => new { it.CUSNO, it.LGPER_CODE })
          .WhenMatched((origin, cur) => new CcicCustomerTypeOrg
          {
              CUSNO = cur.CUSNO,
              LGPER_CODE = cur.LGPER_CODE,
              NTECO_DEPT = cur.NTECO_DEPT,
              ENTP_ECN_CMCLF = cur.ENTP_ECN_CMCLF,
              ENTP_CHAR = cur.ENTP_CHAR,
              OWS_STC_CODE = cur.OWS_STC_CODE,
              ENTP_SZ_MOIMI_STD = cur.ENTP_SZ_MOIMI_STD,
              ENTP_SZ_TB_STD = cur.ENTP_SZ_TB_STD,
              ADMN_HIER = cur.ADMN_HIER,
              RESP_ITFO = cur.RESP_ITFO,
              NONL_SUFLT_ORG_FLAG = cur.NONL_SUFLT_ORG_FLAG,
              YES_SUPR_LGPER_OR_SPVS_UNIT_FLAG = cur.YES_SUPR_LGPER_OR_SPVS_UNIT_FLAG,
              GOVT_FUNC_TP_GOVT_UNIQ = cur.GOVT_FUNC_TP_GOVT_UNIQ,
              ENV_AND_SOC_RSK_CTGY = cur.ENV_AND_SOC_RSK_CTGY,
              SEI_TP_CODE = cur.SEI_TP_CODE,
              HOSP_CUS_LEVEL = cur.HOSP_CUS_LEVEL,
              ORG_TP_CODE = cur.ORG_TP_CODE,
              IDY_REFNO = cur.IDY_REFNO,
              ORG_TYPE_TAX = cur.ORG_TYPE_TAX,
              RSDNT_TAX_IDR = cur.RSDNT_TAX_IDR,
              ORG_TAX_RSDNT_IDNT_TP = cur.ORG_TAX_RSDNT_IDNT_TP,
              TAX_MNT_EFF_DT = cur.TAX_MNT_EFF_DT,
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

    public override async Task<IQueryable<CcicCustomerTypeOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}