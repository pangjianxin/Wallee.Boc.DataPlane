using System;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;

/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
public class CcicAntiMoneyLaunderingKey
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
}