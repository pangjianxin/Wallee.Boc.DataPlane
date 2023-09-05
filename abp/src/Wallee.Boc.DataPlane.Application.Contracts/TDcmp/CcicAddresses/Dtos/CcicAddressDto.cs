using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

[Serializable]
public class CcicAddressDto : EntityDto
{
    public string CUSNO { get; set; } = default!;

    public string? ADDR_TP { get; set; }

    public int ADDR_SN { get; set; }

    public string LGPER_CODE { get; set; } = default!;

    public string? ADDR_LANG { get; set; }

    public string? CNRG { get; set; }

    public string? PRVC_MNCP { get; set; }

    public string? CITY { get; set; }

    public string? CNTY { get; set; }

    public string? ADDR1 { get; set; }

    public string? PSALC { get; set; }

    public string? RTNPT_FLAG { get; set; }

    public string? PS_NAME { get; set; }

    public string? CTY_LNG_CODE { get; set; }

    public string? CTY_RGON_RSK_GRD_CODE { get; set; }

    public string? RLTV_UNNPY_URBN_CODE { get; set; }

    public string? BKCD_URBN_CODE { get; set; }

    public string? REL_TP_CODE { get; set; }

    public DateTime REL_STRT_DT { get; set; }

    public DateTime REL_END_DT { get; set; }

    public DateTime REL_STRT_TIME { get; set; }

    public DateTime REL_END_TIME { get; set; }

    public string? REL_DES { get; set; }

    public string? DEL_FLAG { get; set; }

    public string? CRTR_TLR_REFNO { get; set; }

    public string? CRT_TLR_ORG_REFNO { get; set; }

    public DateTime CRT_DTTM { get; set; }

    public DateTime CUR_ACDT_PERI { get; set; }

    public string? LTST_MOD_TLR_REFNO { get; set; }

    public string? MOD_TLR_ORG_REFNO { get; set; }

    public string? LAST_MNT_STS_CODE { get; set; }

    public DateTime LAST_MOD_DTTM { get; set; }

    public long RCRD_VRSN_SN { get; set; }
}