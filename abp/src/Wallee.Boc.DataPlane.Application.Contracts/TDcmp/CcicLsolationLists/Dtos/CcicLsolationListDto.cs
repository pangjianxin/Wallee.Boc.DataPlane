using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;

/// <summary>
/// 对公隔离清单信息    a82
/// </summary>
[Serializable]
public class CcicLsolationListDto : EntityDto
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
    ///  隔离状态. (字符型(1))
    /// </summary>
    public string? QUARN_STS { get; set; }

    /// <summary>
    ///  隔离类型. (字符型(2))
    /// </summary>
    public string? QUARN_TP { get; set; }

    /// <summary>
    ///  隔离原因. (字符型(120))
    /// </summary>
    public string? QUARN_REASN { get; set; }

    /// <summary>
    ///  删除标志. (字符型(1))
    /// </summary>
    public string DEL_FLAG { get; set; } = default!;

    /// <summary>
    ///  创建人柜员编号. (字符型(7))
    /// </summary>
    public string CRTR_TLR_REFNO { get; set; } = default!;

    /// <summary>
    ///  创建柜员机构编号. (字符型(5))
    /// </summary>
    public string CRT_TLR_ORG_REFNO { get; set; } = default!;

    /// <summary>
    ///  创建日期时间. (日期时间型（6）)
    /// </summary>
    public DateTime CRT_DTTM { get; set; }

    /// <summary>
    ///  当前会计日期. (日期型(8))
    /// </summary>
    public DateTime CUR_ACDT_PERI { get; set; }

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
    public string LAST_MNT_STS_CODE { get; set; } = default!;

    /// <summary>
    ///  最后修改日期时间. (日期时间型（6）)
    /// </summary>
    public DateTime? LAST_MOD_DTTM { get; set; }

    /// <summary>
    ///  记录版本序号. (数值型(20))
    /// </summary>
    public string RCRD_VRSN_SN { get; set; } = default!;

    /// <summary>
    ///  记录清理状态代码. (字符型(1))
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}