using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

public class CcicRegisterRepository : EfCoreRepository<DataPlaneDbContext, CcicRegister>, ICcicRegisterRepository
{
    public CcicRegisterRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<CcicRegister> entities)
    {
        await (await GetDbSetAsync()).UpsertRange(entities)
        .On(it => new { it.CUSNO, it.LGPER_CODE })
        .WhenMatched((origin, cur) => new CcicRegister
        {
            CUSNO = cur.CUSNO,
            LGPER_CODE = cur.LGPER_CODE,
            RGST_CNRG = cur.RGST_CNRG,
            ENTP_INCDT_PERI = cur.ENTP_INCDT_PERI,
            SEAR_DT = cur.SEAR_DT,
            LOUT_DT = cur.LOUT_DT,
            OPRT_MATU_START_DT = cur.OPRT_MATU_START_DT,
            OPRT_MATU_TMT_DT = cur.OPRT_MATU_TMT_DT,
            OPRT_MATU = cur.OPRT_MATU,
            LGPER_FLAG = cur.LGPER_FLAG,
            NO_HV_LGPER_QUA_OF_CUS_TP = cur.NO_HV_LGPER_QUA_OF_CUS_TP,
            RGCAP_CUR = cur.RGCAP_CUR,
            RC_AMT = cur.RC_AMT,
            ARCPT_CUR = cur.ARCPT_CUR,
            ARCPT_AMT = cur.ARCPT_AMT,
            ORGN_FNDS_CUR = cur.ORGN_FNDS_CUR,
            ORGN_FNDS_AMT = cur.ORGN_FNDS_AMT,
            FEE_SRC = cur.FEE_SRC,
            CARE_UNBDG_TP = cur.CARE_UNBDG_TP,
            SHR_TOTAL = cur.SHR_TOTAL,
            ISSU_EQU_AMT = cur.ISSU_EQU_AMT,
            BZSCP = cur.BZSCP,
            BSN_SCOP = cur.BSN_SCOP,
            PRCLN_AND_BSN_SCOP_DES = cur.PRCLN_AND_BSN_SCOP_DES,
            MAINB_1_SCOP_NOTE = cur.MAINB_1_SCOP_NOTE,
            MAINB_2_SCOP_NOTE = cur.MAINB_2_SCOP_NOTE,
            MAINB_3_SCOP_NOTE = cur.MAINB_3_SCOP_NOTE,
            IVS_PRJ_ENTP_INFO_NOTE = cur.IVS_PRJ_ENTP_INFO_NOTE,
            MIX_SCOP = cur.MIX_SCOP,
            AVY_TRTY = cur.AVY_TRTY,
            HOST_UNIT_NAME = cur.HOST_UNIT_NAME,
            BSN_SPVS_UNIT_NAME = cur.BSN_SPVS_UNIT_NAME,
            IDBZ_BSNLC_WORD_NO_NAME = cur.IDBZ_BSNLC_WORD_NO_NAME,
            IDBZ_BSNLC_COMP_ITFO_DES = cur.IDBZ_BSNLC_COMP_ITFO_DES,
            IDBZ_BSNLC_BZSCP_AND_MOD_DES = cur.IDBZ_BSNLC_BZSCP_AND_MOD_DES,
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

    public override async Task<IQueryable<CcicRegister>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}