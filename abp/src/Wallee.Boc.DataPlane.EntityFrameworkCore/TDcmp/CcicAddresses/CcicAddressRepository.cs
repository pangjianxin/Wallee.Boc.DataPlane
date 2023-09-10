using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

public class CcicAddressRepository : EfCoreRepository<DataPlaneDbContext, CcicAddress>, ICcicAddressRepository
{
    public CcicAddressRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicAddress>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    public async Task UpsertAsync(IEnumerable<CcicAddress> list)
    {
        await (await GetDbSetAsync()).UpsertRange(list)
            .On(it => new { it.CUSNO, it.ADDR_TP, it.ADDR_SN, it.LGPER_CODE })
            .WhenMatched((origin, cur) => new CcicAddress
            {
                CUSNO = cur.CUSNO,
                ADDR_TP = cur.ADDR_TP,
                ADDR_SN = cur.ADDR_SN,
                LGPER_CODE = cur.LGPER_CODE,
                ADDR_LANG = cur.ADDR_LANG,
                CNRG = cur.CNRG,
                PRVC_MNCP = cur.PRVC_MNCP,
                CITY = cur.CITY,
                CNTY = cur.CNTY,
                ADDR1 = cur.ADDR1,
                PSALC = cur.PSALC,
                RTNPT_FLAG = cur.RTNPT_FLAG,
                PS_NAME = cur.PS_NAME,
                CTY_LNG_CODE = cur.CTY_LNG_CODE,
                CTY_RGON_RSK_GRD_CODE = cur.CTY_RGON_RSK_GRD_CODE,
                RLTV_UNNPY_URBN_CODE = cur.RLTV_UNNPY_URBN_CODE,
                BKCD_URBN_CODE = cur.BKCD_URBN_CODE,
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
}