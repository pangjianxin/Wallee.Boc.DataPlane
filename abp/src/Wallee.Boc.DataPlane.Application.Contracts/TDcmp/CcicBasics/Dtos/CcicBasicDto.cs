using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

/// <summary>
/// 对公客户基础信息
/// </summary>
[Serializable]
public class CcicBasicDto : EntityDto
{
    /// <summary>
    /// 客户号
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 法人编码
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    /// 终身编码
    /// </summary>
    public string? AL_CODE { get; set; }

    /// <summary>
    /// 通讯语言
    /// </summary>
    public string? COMM_LNG { get; set; }

    /// <summary>
    /// 客户关系建立渠道
    /// </summary>
    public string? CUSRL_TE_CHNL { get; set; }

    /// <summary>
    /// 客户经理柜员编号
    /// </summary>
    public string? CSMGR_TLR_REFNO { get; set; }

    /// <summary>
    /// 开户机构编号
    /// </summary>
    public string? OPNAC_ORG_REFNO { get; set; }

    /// <summary>
    /// 归属机构编号
    /// </summary>
    public string? BLG_ORG_REFNO { get; set; }

    /// <summary>
    /// 开户日期
    /// </summary>
    public DateTime? OPNAC_DT { get; set; }

    /// <summary>
    /// 关闭日期
    /// </summary>
    public DateTime? CLS_DT { get; set; }

    /// <summary>
    /// 最后确认日期
    /// </summary>
    public DateTime LAST_CNMDT_PERI { get; set; }

    /// <summary>
    /// 客户状态
    /// </summary>
    public string? CSTST { get; set; }

    /// <summary>
    /// 停用原因
    /// </summary>
    public string? DSABL_REASN { get; set; }

    /// <summary>
    /// 停用原因说明
    /// </summary>
    public string? DSABL_REASN_NOTE { get; set; }

    /// <summary>
    /// 参与方角色类型代码
    /// </summary>
    public string? PART_RL_TP_CODE { get; set; }

    /// <summary>
    /// 删除标志
    /// </summary>
    public string? DEL_FLAG { get; set; }

    /// <summary>
    /// 创建人柜员编号
    /// </summary>
    public string? CRTR_TLR_REFNO { get; set; }

    /// <summary>
    /// 创建柜员机构编号
    /// </summary>
    public string? CRT_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// 创建日期时间
    /// </summary>
    public DateTime CRT_DTTM { get; set; }

    /// <summary>
    /// 当前会计日期
    /// </summary>
    public DateTime CUR_ACDT_PERI { get; set; }

    /// <summary>
    /// 最新修改柜员编号
    /// </summary>
    public string? LTST_MOD_TLR_REFNO { get; set; }

    /// <summary>
    /// 修改柜员机构编号
    /// </summary>
    public string? MOD_TLR_ORG_REFNO { get; set; }

    /// <summary>
    /// 最后维护状态代码
    /// </summary>
    public string? LAST_MNT_STS_CODE { get; set; }

    /// <summary>
    /// 最后修改日期时间
    /// </summary>
    public DateTime LAST_MOD_DTTM { get; set; }

    /// <summary>
    /// 记录版本序号
    /// </summary>
    public decimal RCRD_VRSN_SN { get; set; }

    /// <summary>
    /// 记录清理状态代码
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}