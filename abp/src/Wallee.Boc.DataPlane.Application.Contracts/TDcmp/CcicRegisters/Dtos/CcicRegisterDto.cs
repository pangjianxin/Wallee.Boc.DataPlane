using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;

/// <summary>
/// 对公注册信息    a28
/// </summary>
[Serializable]
public class CcicRegisterDto : EntityDto
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    ///  注册国家/地区. (字符型(3))
    /// </summary>
    public string? RGST_CNRG { get; set; }

    /// <summary>
    ///  企业成立日期. (日期型(8))
    /// </summary>
    public DateTime? ENTP_INCDT_PERI { get; set; }

    /// <summary>
    ///  查册日期. (日期型(8))
    /// </summary>
    public DateTime? SEAR_DT { get; set; }

    /// <summary>
    ///  注销日期. (日期型(8))
    /// </summary>
    public DateTime? LOUT_DT { get; set; }

    /// <summary>
    ///  经营期限起始日期. (日期型(8))
    /// </summary>
    public DateTime? OPRT_MATU_START_DT { get; set; }

    /// <summary>
    ///  经营期限终止日期. (日期型(8))
    /// </summary>
    public DateTime? OPRT_MATU_TMT_DT { get; set; }

    /// <summary>
    ///  经营期限. (数值型(3))
    /// </summary>
    public decimal? OPRT_MATU { get; set; }

    /// <summary>
    ///  法人标志. (字符型(1))
    /// </summary>
    public string? LGPER_FLAG { get; set; }

    /// <summary>
    ///  不具备法人资格的客户类型. (字符型(2))
    /// </summary>
    public string? NO_HV_LGPER_QUA_OF_CUS_TP { get; set; }

    /// <summary>
    ///  注册资本币种. (字符型(3))
    /// </summary>
    public string? RGCAP_CUR { get; set; }

    /// <summary>
    ///  注册资本金额. (数值型(18,3))
    /// </summary>
    public decimal? RC_AMT { get; set; }

    /// <summary>
    ///  实收资本币种. (字符型(3))
    /// </summary>
    public string? ARCPT_CUR { get; set; }

    /// <summary>
    ///  实收资本金额. (数值型(18,3))
    /// </summary>
    public decimal? ARCPT_AMT { get; set; }

    /// <summary>
    ///  开办资金币种. (字符型(3))
    /// </summary>
    public string? ORGN_FNDS_CUR { get; set; }

    /// <summary>
    ///  开办资金金额. (数值型(18,3))
    /// </summary>
    public decimal? ORGN_FNDS_AMT { get; set; }

    /// <summary>
    ///  经费来源. (字符型(50))
    /// </summary>
    public string? FEE_SRC { get; set; }

    /// <summary>
    ///  事业单位预算类型. (字符型(1))
    /// </summary>
    public string? CARE_UNBDG_TP { get; set; }

    /// <summary>
    ///  股份总数. (数值型(24,6))
    /// </summary>
    public decimal? SHR_TOTAL { get; set; }

    /// <summary>
    ///  发行股本金额. (数值型(18,3))
    /// </summary>
    public decimal? ISSU_EQU_AMT { get; set; }

    /// <summary>
    ///  经营范围. (字符型(1000))
    /// </summary>
    public string? BZSCP { get; set; }

    /// <summary>
    ///  业务范围. (字符型(1000))        </summary
    /// </summary>
    public string? BSN_SCOP { get; set; }

    /// <summary>
    ///  宗旨和业务范围描述. (字符型(1000))
    /// </summary>
    public string? PRCLN_AND_BSN_SCOP_DES { get; set; }

    /// <summary>
    ///  主营业务1范围说明. (字符型(500))
    /// </summary>
    public string? MAINB_1_SCOP_NOTE { get; set; }

    /// <summary>
    ///  主营业务2范围说明. (字符型(500))
    /// </summary>
    public string? MAINB_2_SCOP_NOTE { get; set; }

    /// <summary>
    ///  主营业务3范围说明. (字符型(500))
    /// </summary>
    public string? MAINB_3_SCOP_NOTE { get; set; }

    /// <summary>
    ///  投资项目/企业情况说明. (字符型(100))
    /// </summary>
    public string? IVS_PRJ_ENTP_INFO_NOTE { get; set; }

    /// <summary>
    ///  兼营范围. (字符型(40))
    /// </summary>
    public string? MIX_SCOP { get; set; }

    /// <summary>
    ///  活动地域. (字符型(80))
    /// </summary>
    public string? AVY_TRTY { get; set; }

    /// <summary>
    ///  举办单位名称. (字符型(80))
    /// </summary>
    public string? HOST_UNIT_NAME { get; set; }

    /// <summary>
    ///  业务主管单位名称. (字符型(120))
    /// </summary>
    public string? BSN_SPVS_UNIT_NAME { get; set; }

    /// <summary>
    ///  个体工商户营业执照-字号名称. (字符型(500))
    /// </summary>
    public string? IDBZ_BSNLC_WORD_NO_NAME { get; set; }

    /// <summary>
    ///  个体工商户营业执照-组成形式描述. (字符型(50))
    /// </summary>
    public string? IDBZ_BSNLC_COMP_ITFO_DES { get; set; }

    /// <summary>
    ///  个体工商户营业执照-经营范围及方式描述. (字符型(1000))
    /// </summary>
    public string? IDBZ_BSNLC_BZSCP_AND_MOD_DES { get; set; }

    /// <summary>
    ///  删除标志. (字符型(1))
    /// </summary>
    public string? DEL_FLAG { get; set; }

    /// <summary>
    ///  创建人柜员编号. (字符型(7))
    /// </summary>
    public string? CRTR_TLR_REFNO { get; set; }

    /// <summary>
    ///  创建柜员机构编号. (字符型(5))
    /// </summary>
    public string? CRT_TLR_ORG_REFNO { get; set; }

    /// <summary>
    ///  创建日期时间. (日期时间型)
    /// </summary>
    public DateTime? CRT_DTTM { get; set; }

    /// <summary>
    ///  当前会计日期. (日期型(8))
    /// </summary>
    public DateTime? CUR_ACDT_PERI { get; set; }

    /// <summary>
    ///  最新修改柜员编号. (字符型(7))
    /// </summary>
    public string? LTST_MOD_TLR_REFNO { get; set; }

    /// <summary>
    ///  修改柜员机构编号. (字符型(5))
    /// </summary>
    public string? MOD_TLR_ORG_REFNO { get; set; }

    /// <summary>
    ///  最后维护状态代码. (字符型(1))
    /// </summary>
    public string? LAST_MNT_STS_CODE { get; set; }

    /// <summary>
    ///  最后修改日期时间. (日期时间型)
    /// </summary>
    public DateTime? LAST_MOD_DTTM { get; set; }

    /// <summary>
    ///  记录版本序号. (数值型(20))
    /// </summary>
    public string? RCRD_VRSN_SN { get; set; }

    /// <summary>
    ///  记录清理状态代码. (字符型(1))
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}