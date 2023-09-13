using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;

/// <summary>
/// 对公运营信息    a26
/// </summary>
[Serializable]
public class CcicPracticeDto : EntityDto
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  经营信息序号. (数值型(5))
    /// </summary>
    public int OPRT_INF_SN { get; set; }

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    ///  经营情况统计年度. (日期型(4))
    /// </summary>
    public string? OPRT_INFO_STAT_YR { get; set; }

    /// <summary>
    ///  经营情况统计期次. (数值型(2))
    /// </summary>
    public decimal? OPRT_INFO_STAT_INST { get; set; }

    /// <summary>
    ///  企业成长阶段代码. (字符型(1))
    /// </summary>
    public string? ENTP_GRWUP_STG_CODE { get; set; }

    /// <summary>
    ///  企业经营状态. (字符型(2))
    /// </summary>
    public string? ENTP_OPRT_STS { get; set; }

    /// <summary>
    ///  客户经营状态起始日期. (日期型(8))
    /// </summary>
    public DateTime? CUS_OPRT_STS_START_DT { get; set; }

    /// <summary>
    ///  客户经营状态终止日期. (日期型(8))
    /// </summary>
    public DateTime? CUS_OPRT_STS_TMT_DT { get; set; }

    /// <summary>
    ///  情况简介. (字符型(120))
    /// </summary>
    public string? INFO_OVW { get; set; }

    /// <summary>
    ///  跨行业经营标志. (字符型(1))
    /// </summary>
    public string? CROSS_IDY_OPRT_FLAG { get; set; }

    /// <summary>
    ///  主导产品及品牌描述. (字符型(100))
    /// </summary>
    public string? LEAD_PD_AND_BRND_DES { get; set; }

    /// <summary>
    ///  品牌价值币种. (字符型(3))
    /// </summary>
    public string? BRND_VAL_CUR { get; set; }

    /// <summary>
    ///  品牌价值. (数值型(18,3))
    /// </summary>
    public decimal? BRND_VAL { get; set; }

    /// <summary>
    ///  品牌知名度. (字符型(100))
    /// </summary>
    public string? BRND_VISI { get; set; }

    /// <summary>
    ///  品牌知名度调查机构名称. (字符型(500))
    /// </summary>
    public string? BRND_VISI_SURVY_ORG_NAME { get; set; }

    /// <summary>
    ///  企业产品生命周期. (字符型(1))
    /// </summary>
    public string? ENTP_PD_LIFE_CYCLE { get; set; }

    /// <summary>
    ///  商业活动旺季标识. (字符型(4))
    /// </summary>
    public string? CMRC_AVY_PEAK_IDR { get; set; }

    /// <summary>
    ///  主要原材料描述. (字符型(200))
    /// </summary>
    public string? MAIN_ORI_MTRL_DES { get; set; }

    /// <summary>
    ///  从业人数. (数值型(7))
    /// </summary>
    public decimal? CRER_PNUM { get; set; }

    /// <summary>
    ///  公司员工平均年龄. (数值型(5,2))
    /// </summary>
    public decimal? CO_EMPE_AVGAG { get; set; }

    /// <summary>
    ///  销售收入币种. (字符型(3))
    /// </summary>
    public string? SALES_CUR { get; set; }

    /// <summary>
    ///  销售收入金额. (数值型(18,3))
    /// </summary>
    public decimal? SALES_AMT { get; set; }

    /// <summary>
    ///  资产总额币种. (字符型(3))
    /// </summary>
    public string? AST_TAMT_CUR { get; set; }

    /// <summary>
    ///  资产总额. (数值型(18,3))
    /// </summary>
    public decimal? AST_TAMT { get; set; }

    /// <summary>
    ///  净资产币种. (字符型(3))
    /// </summary>
    public string? NTAST_CUR { get; set; }

    /// <summary>
    ///  净资产金额. (数值型(18,3))
    /// </summary>
    public decimal? NTAST_AMT { get; set; }

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