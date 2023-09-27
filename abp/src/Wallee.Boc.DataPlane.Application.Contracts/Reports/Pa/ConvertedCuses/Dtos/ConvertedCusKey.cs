using System;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

/// <summary>
/// 折效客户明细
/// </summary>
public class ConvertedCusKey
{
    /// <summary>
    /// 数据日期
    /// </summary>
    public DateTime DataDate { get; set; }

    /// <summary>
    /// 客户号
    /// </summary>
    public string Cusidt { get; set; } = default!;
}