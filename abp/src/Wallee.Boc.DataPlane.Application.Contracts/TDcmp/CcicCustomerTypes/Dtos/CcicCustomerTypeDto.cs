using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;

/// <summary>
/// 对公客户类别信息    a08
/// </summary>
[Serializable]
public class CcicCustomerTypeDto : EntityDto
{
    /// <summary>
    /// 客户号        字符型(10)
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 法人编码        字符型(3)
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;

    /// <summary>
    /// 客户类型        字符型(2)
    /// </summary>
    public string? CUS_TP { get; set; }

    /// <summary>
    /// 客户子类型        字符型(3)
    /// </summary>
    public string? CUS_SUBTP { get; set; }

    /// <summary>
    /// 行业分类        字符型(5)
    /// </summary>
    public string? INDCL { get; set; }

    /// <summary>
    /// FAIRS客户分类        字符型(2)
    /// </summary>
    public string? FAIRS_CUS_CTGY { get; set; }

    /// <summary>
    /// SPV客户类型        字符型(1)
    /// </summary>
    public string? SPV_CUS_TP { get; set; }

    /// <summary>
    /// 隶属行政区划(政府特有)        字符型(6)
    /// </summary>
    public string? SOD_ADIV_GOVT_UNIQ { get; set; }

    /// <summary>
    /// 事业单位类别代码        字符型(1)
    /// </summary>
    public string? CRERU_TYPE_CODE { get; set; }

    /// <summary>
    /// 新模式客户标识        字符型(2)
    /// </summary>
    public string? NEW_MODE_CUS_IDR { get; set; }

    /// <summary>
    /// 医院客户性质分类        字符型(1)
    /// </summary>
    public string? HOSP_CUS_CHAR_CTGY { get; set; }

    /// <summary>
    /// 教育行业客户性质分类        字符型(1)
    /// </summary>
    public string? ED_IDY_CUS_CHAR_CTGY { get; set; }

    /// <summary>
    /// 教育行业客户分类        字符型(3)
    /// </summary>
    public string? ED_IDY_CUS_CTGY { get; set; }

    /// <summary>
    /// 客户分类(本地)        字符型(2)
    /// </summary>
    public string? CUS_CTGY_LCL { get; set; }

    /// <summary>
    /// 客户分类状态        字符型(1)
    /// </summary>
    public string? CUS_CTGY_STS { get; set; }

    /// <summary>
    /// 客户归属条线        字符型(1)
    /// </summary>
    public string? CUS_BLG_LINE { get; set; }

    /// <summary>
    /// 客户组织        字符型(1)
    /// </summary>
    public string? CUS_ORG { get; set; }

    /// <summary>
    /// 低风险因素的商业机构类型名称        字符型(3)
    /// </summary>
    public string? LWRS_FACT_OF_CMRC_ORG_TP_NAME { get; set; }

    /// <summary>
    /// 补充客户类型(风险口径)        字符型(6)
    /// </summary>
    public string? SPLMT_CUS_TP_RSK_CLBR { get; set; }

    /// <summary>
    /// 公检法客户级别代码        字符型(2)
    /// </summary>
    public string? PPPC_CUS_LEVEL_CODE { get; set; }

    /// <summary>
    /// 卫生客户类型        字符型(1)
    /// </summary>
    public string? HEAL_CUS_TP { get; set; }

    /// <summary>
    /// 客户分层        字符型(2)
    /// </summary>
    public string? CUS_LYR { get; set; }

    /// <summary>
    /// 客户来源        字符型(120)
    /// </summary>
    public string? CUS_SRC { get; set; }

    /// <summary>
    /// 客户忠诚度        数值型(6,2)
    /// </summary>
    public decimal? CUS_LYLT { get; set; }

    /// <summary>
    /// 活跃度分数        数值型(5,2)
    /// </summary>
    public decimal? AVY_SCOR { get; set; }

    /// <summary>
    /// 需要提供财务报表频度代码        字符型(2)
    /// </summary>
    public string? REQ_PRVD_FNRPT_FRQC_CODE { get; set; }

    /// <summary>
    /// 客户大类代码        字符型(1)
    /// </summary>
    public string? CUS_LGCLS_CODE { get; set; }

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
    public decimal? RCRD_VRSN_SN { get; set; }

    /// <summary>
    /// 记录清理状态代码        字符型(1)
    /// </summary>
    public string? RCRD_CLNUP_STSCD { get; set; }
}