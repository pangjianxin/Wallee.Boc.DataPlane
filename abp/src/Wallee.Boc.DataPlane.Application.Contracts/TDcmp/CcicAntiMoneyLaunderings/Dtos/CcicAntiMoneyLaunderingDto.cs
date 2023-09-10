using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;

/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
[Serializable]
public class CcicAntiMoneyLaunderingDto : EntityDto
{
    /// <summary>
    /// 客户号        字符型(10)
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 反洗钱信息序号        数值型(3)
    /// </summary>
    public int AML_INF_SN { get; set; }

    /// <summary>
    /// 法人编码        字符型(3)
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    /// 预期月交易规模金额        数值型(18,3)
    /// </summary>
    public decimal? EXPC_MO_TXN_SZ_AMT { get; set; }

    /// <summary>
    /// 预期月交易规模币种        字符型(3)
    /// </summary>
    public string? EXPC_MO_TXN_SZ_CUR { get; set; }

    /// <summary>
    /// CRR客户子类型        字符型(4)
    /// </summary>
    public string? CRRCUS_CODE { get; set; }

    /// <summary>
    /// SDD客户类型        字符型(2)
    /// </summary>
    public string? SDD_CUS_TP { get; set; }

    /// <summary>
    /// 建立客户关系目的        字符型(60)
    /// </summary>
    public string? TE_CUSRL_PPS { get; set; }

    /// <summary>
    /// 建立客户关系目的其他原因        字符型(40)
    /// </summary>
    public string? PURPOSE_REMARK { get; set; }

    /// <summary>
    /// 受益所有人识别情况        字符型(3)
    /// </summary>
    public string? BENEO_ID_INFO { get; set; }

    /// <summary>
    /// 无法识别受益所有人原因        字符型(300)
    /// </summary>
    public string? CANNO_ID_BENEO_REASN { get; set; }

    /// <summary>
    /// 在外部制裁名单标志        字符型(1)
    /// </summary>
    public string? EXST_EXT_SANCT_NMLST_FLAG { get; set; }

    /// <summary>
    /// 政要标志        字符型(1)
    /// </summary>
    public string? POLI_FLAG { get; set; }

    /// <summary>
    /// CRR风险等级代码        字符型(1)
    /// </summary>
    public string? CRR_RSK_GRD_CODE { get; set; }

    /// <summary>
    /// 反洗钱风险等级有效起始日期        日期型(8)
    /// </summary>
    public DateTime? AML_RSK_GRD_VLD_START_DT { get; set; }

    /// <summary>
    /// 反洗钱风险等级有效终止日期        日期型(8)
    /// </summary>
    public DateTime? AML_RSK_GRD_VLD_TMT_DT { get; set; }

    /// <summary>
    /// 删除标志        字符型(1)
    /// </summary>
    public string? DEL_FLAG { get; set; }

    /// <summary>
    /// 创建人柜员编号        字符型(7)
    /// </summary>
    public string? CRTR_TLR_REFNO { get; set; }

    /// <summary>
    /// 创建柜员机构编号        字符型(5)
    /// </summary>
    public string? CRT_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// 创建日期时间        日期时间型
    /// </summary>
    public DateTime? CRT_DTTM { get; set; }

    /// <summary>
    /// 当前会计日期        日期型(8)
    /// </summary>
    public DateTime? CUR_ACDT_PERI { get; set; }

    /// <summary>
    /// 最新修改柜员编号        字符型(7)
    /// </summary>
    public string? LTST_MOD_TLR_REFNO { get; set; }

    /// <summary>
    /// 修改柜员机构编号        字符型(5)
    /// </summary>
    public string? MOD_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// 最后维护状态代码        字符型(1)
    /// </summary>
    public string? LAST_MNT_STS_CODE { get; set; }

    /// <summary>
    /// 最后修改日期时间        日期时间型
    /// </summary>
    public DateTime? LAST_MOD_DTTM { get; set; }

    /// <summary>
    /// 记录版本序号        数值型(20)
    /// </summary>
    public string? RCRD_VRSN_SN { get; set; }

    /// <summary>
    /// 记录清理状态代码        字符型(1)
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}