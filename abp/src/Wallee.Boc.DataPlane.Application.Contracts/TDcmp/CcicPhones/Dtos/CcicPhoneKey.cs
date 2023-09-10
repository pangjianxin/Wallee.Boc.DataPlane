using System;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones.Dtos;

/// <summary>
/// 对公名称信息    a22
/// </summary>
public class CcicPhoneKey
{
    /// <summary>
    /// 客户号        字符型(10)
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 单位电话类型        字符型(2)
    /// </summary>
    public string UNIT_TEL_TP { get; set; } = default!;

    /// <summary>
    /// 联系电话序号        数值型(3)
    /// </summary>
    public int CNTEL_SN { get; set; }

    /// <summary>
    /// 法人编码        字符型(3)
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}