namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;

/// <summary>
/// 对公隔离清单信息    a82
/// </summary>
public class CcicLsolationListKey
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}