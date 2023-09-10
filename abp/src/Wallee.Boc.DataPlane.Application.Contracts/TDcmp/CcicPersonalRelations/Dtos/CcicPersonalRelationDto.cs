using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;

/// <summary>
/// 对公人员关系    a24
/// </summary>
[Serializable]
public class CcicPersonalRelationDto : EntityDto
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  关系/角色. (字符型(7))
    /// </summary>
    public string REL_RL { get; set; } = default!;

    /// <summary>
    ///  关系人客户号码. (字符型(10))
    /// </summary>
    public string PRINT_CUSNO_YARD { get; set; } = default!;

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    ///  关系描述. (字符型(120))
    /// </summary>
    public string? REL_DES { get; set; }

    /// <summary>
    ///  关系开始日期. (日期型(8))
    /// </summary>
    public DateTime? REL_STRT_DT { get; set; }

    /// <summary>
    ///  关系结束日期. (日期型(8))
    /// </summary>
    public DateTime? REL_END_DT { get; set; }

    /// <summary>
    ///  关系开始时间. (时间(8))
    /// </summary>
    public TimeSpan? REL_STRT_TIME { get; set; }

    /// <summary>
    ///  关系结束时间. (时间(8))
    /// </summary>
    public TimeSpan? REL_END_TIME { get; set; }

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