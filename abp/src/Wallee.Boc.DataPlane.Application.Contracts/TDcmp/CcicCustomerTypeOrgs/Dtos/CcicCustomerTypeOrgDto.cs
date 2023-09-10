using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs.Dtos;

/// <summary>
/// 对公客户类别信息-组织    a09
/// </summary>
[Serializable]
public class CcicCustomerTypeOrgDto : EntityDto
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
    ///  国民经济部门. (字符型(3))
    /// </summary>
    public string? NTECO_DEPT { get; set; }

    /// <summary>
    ///  企业经济成分. (字符型(5))
    /// </summary>
    public string? ENTP_ECN_CMCLF { get; set; }

    /// <summary>
    ///  企业性质. (字符型(1))
    /// </summary>
    public string? ENTP_CHAR { get; set; }

    /// <summary>
    ///  所有权结构代码. (字符型(1))
    /// </summary>
    public string? OWS_STC_CODE { get; set; }

    /// <summary>
    ///  企业规模(工信部标准). (字符型(1))
    /// </summary>
    public string? ENTP_SZ_MOIMI_STD { get; set; }

    /// <summary>
    ///  企业规模(税务局标准). (字符型(2))
    /// </summary>
    public string? ENTP_SZ_TB_STD { get; set; }

    /// <summary>
    ///  行政层级. (字符型(1))
    /// </summary>
    public string? ADMN_HIER { get; set; }

    /// <summary>
    ///  责任形式. (字符型(5))
    /// </summary>
    public string? RESP_ITFO { get; set; }

    /// <summary>
    ///  外地常设机构标志. (字符型(1))
    /// </summary>
    public string? NONL_SUFLT_ORG_FLAG { get; set; }

    /// <summary>
    ///  有上级法人或主管单位标志. (字符型(1))
    /// </summary>
    public string? YES_SUPR_LGPER_OR_SPVS_UNIT_FLAG { get; set; }

    /// <summary>
    ///  政府职能类型(政府特有). (字符型(2))
    /// </summary>
    public string? GOVT_FUNC_TP_GOVT_UNIQ { get; set; }

    /// <summary>
    ///  环境和社会风险分类. (字符型(1))
    /// </summary>
    public string? ENV_AND_SOC_RSK_CTGY { get; set; }

    /// <summary>
    ///  战略新兴产业类型代码. (字符型(2))
    /// </summary>
    public string? SEI_TP_CODE { get; set; }

    /// <summary>
    ///  医院客户级别. (字符型(2))
    /// </summary>
    public string? HOSP_CUS_LEVEL { get; set; }

    /// <summary>
    ///  组织类型代码. (字符型(8))
    /// </summary>
    public string? ORG_TP_CODE { get; set; }

    /// <summary>
    ///  行业编号. (字符型(5))
    /// </summary>
    public string? IDY_REFNO { get; set; }

    /// <summary>
    ///  机构类别(涉税). (字符型(1))
    /// </summary>
    public string? ORG_TYPE_TAX { get; set; }

    /// <summary>
    ///  居民涉税标识. (字符型(1))
    /// </summary>
    public string? RSDNT_TAX_IDR { get; set; }

    /// <summary>
    ///  机构税收居民身份类型. (字符型(1))
    /// </summary>
    public string? ORG_TAX_RSDNT_IDNT_TP { get; set; }

    /// <summary>
    ///  涉税维护生效日期. (日期型(8))
    /// </summary>
    public DateTime? TAX_MNT_EFF_DT { get; set; }

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