using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

public class CcicCustomerTypeRepository : EfCoreRepository<DataPlaneDbContext, CcicCustomerType>, ICcicCustomerTypeRepository
{
    public CcicCustomerTypeRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicCustomerType> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
         .On(it => new { it.CUSNO, it.LGPER_CODE })
         .WhenMatched((origin, cur) => new CcicCustomerType
         {
             CUSNO = cur.CUSNO,
             LGPER_CODE = cur.LGPER_CODE,
             CUS_TP = cur.CUS_TP,
             CUS_SUBTP = cur.CUS_SUBTP,
             INDCL = cur.INDCL,
             FAIRS_CUS_CTGY = cur.FAIRS_CUS_CTGY,
             SPV_CUS_TP = cur.SPV_CUS_TP,
             SOD_ADIV_GOVT_UNIQ = cur.SOD_ADIV_GOVT_UNIQ,
             CRERU_TYPE_CODE = cur.CRERU_TYPE_CODE,
             NEW_MODE_CUS_IDR = cur.NEW_MODE_CUS_IDR,
             HOSP_CUS_CHAR_CTGY = cur.HOSP_CUS_CHAR_CTGY,
             ED_IDY_CUS_CHAR_CTGY = cur.ED_IDY_CUS_CHAR_CTGY,
             ED_IDY_CUS_CTGY = cur.ED_IDY_CUS_CTGY,
             CUS_CTGY_LCL = cur.CUS_CTGY_LCL,
             CUS_CTGY_STS = cur.CUS_CTGY_STS,
             CUS_BLG_LINE = cur.CUS_BLG_LINE,
             CUS_ORG = cur.CUS_ORG,
             LWRS_FACT_OF_CMRC_ORG_TP_NAME = cur.LWRS_FACT_OF_CMRC_ORG_TP_NAME,
             SPLMT_CUS_TP_RSK_CLBR = cur.SPLMT_CUS_TP_RSK_CLBR,
             PPPC_CUS_LEVEL_CODE = cur.PPPC_CUS_LEVEL_CODE,
             HEAL_CUS_TP = cur.HEAL_CUS_TP,
             CUS_LYR = cur.CUS_LYR,
             CUS_SRC = cur.CUS_SRC,
             CUS_LYLT = cur.CUS_LYLT,
             AVY_SCOR = cur.AVY_SCOR,
             REQ_PRVD_FNRPT_FRQC_CODE = cur.REQ_PRVD_FNRPT_FRQC_CODE,
             CUS_LGCLS_CODE = cur.CUS_LGCLS_CODE,
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

    public override async Task<IQueryable<CcicCustomerType>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}