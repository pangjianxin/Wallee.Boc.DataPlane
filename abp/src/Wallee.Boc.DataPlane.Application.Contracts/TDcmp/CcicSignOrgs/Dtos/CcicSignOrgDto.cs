using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;

/// <summary>
/// 对公重要标志信息-组织    a35
/// </summary>
[Serializable]
public class CcicSignOrgDto : EntityDto
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
    ///  上级单位法人/负责人类型. (字符型(1))
    /// </summary>
    public string? SUPR_UNIT_LGPER_PNP_TP { get; set; }

    /// <summary>
    ///  上市公司标志. (字符型(1))
    /// </summary>
    public string? LSTCO_FLAG { get; set; }

    /// <summary>
    ///  高新技术企业标志. (字符型(1))
    /// </summary>
    public string? HTCHE_FLAG { get; set; }

    /// <summary>
    ///  免登记社会团体标志. (字符型(1))
    /// </summary>
    public string? EXMPT_RGS_SOC_GROU_FLAG { get; set; }

    /// <summary>
    ///  非盈利性机构标志. (字符型(1))
    /// </summary>
    public string? NON_PFT_PROP_ORG_FLAG { get; set; }

    /// <summary>
    ///  严重违法记录标志. (字符型(1))
    /// </summary>
    public string? SERIS_ILLG_RCRD_FLAG { get; set; }

    /// <summary>
    ///  位置位于自贸区内标志. (字符型(1))
    /// </summary>
    public string? PS_LIT_FTA_WITH_FLAG { get; set; }

    /// <summary>
    ///  中央政府投资公用企业标志. (字符型(1))
    /// </summary>
    public string? PUBEN_FLAG { get; set; }

    /// <summary>
    ///  中国国控企业标志. (字符型(1))
    /// </summary>
    public string? CHINA_SCE_FLAG { get; set; }

    /// <summary>
    ///  民营企业标志. (字符型(1))
    /// </summary>
    public string? TPE_FLAG { get; set; }

    /// <summary>
    ///  违法失信标志. (字符型(1))
    /// </summary>
    public string? ILLG_DISH_FLAG { get; set; }

    /// <summary>
    ///  特殊经济区内企业标志. (字符型(1))
    /// </summary>
    public string? SPCL_ECORE_ENTP_FLAG { get; set; }

    /// <summary>
    ///  涉农标志. (字符型(1))
    /// </summary>
    public string? AGRO_FLAG { get; set; }

    /// <summary>
    ///  三农企业标志. (字符型(1))
    /// </summary>
    public string? ARAAF_ENTP_FLAG { get; set; }

    /// <summary>
    ///  欧盟组织标志. (字符型(1))
    /// </summary>
    public string? EU_ORG_FLAG { get; set; }

    /// <summary>
    ///  科创类企业标志. (字符型(1))
    /// </summary>
    public string? SATI_ENTP_FLAG { get; set; }

    /// <summary>
    ///  金融扶贫标志. (字符型(1))
    /// </summary>
    public string? FNC_PVRT_FLAG { get; set; }

    /// <summary>
    ///  独角兽企业标志. (字符型(1))
    /// </summary>
    public string? UNIC_ENTP_FLAG { get; set; }

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