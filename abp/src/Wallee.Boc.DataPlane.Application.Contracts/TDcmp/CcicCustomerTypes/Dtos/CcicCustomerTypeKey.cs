namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;

/// <summary>
/// 对公客户类别信息    a08
/// </summary>
public class CcicCustomerTypeKey
{
    /// <summary>
    /// 客户号        字符型(10)
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 法人编码        字符型(3)
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}