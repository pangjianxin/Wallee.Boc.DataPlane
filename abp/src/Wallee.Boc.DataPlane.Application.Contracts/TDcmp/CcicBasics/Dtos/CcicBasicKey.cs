using System;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

/// <summary>
/// 对公客户基础信息
/// </summary>
public class CcicBasicKey
{
    /// <summary>
    /// 客户号
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 法人编码
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}