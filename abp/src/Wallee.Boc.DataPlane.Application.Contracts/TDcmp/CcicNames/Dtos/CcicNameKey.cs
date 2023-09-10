namespace Wallee.Boc.DataPlane.TDcmp.CcicNames.Dtos;

/// <summary>
/// 对公名称信息    a22
/// </summary>
public class CcicNameKey
{
    /// <summary>
    /// 客户号        字符型(10)
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    /// 客户名称语种        字符型(2)
    /// </summary>
    public string CUS_NAME_LANG { get; set; } = default!;

    /// <summary>
    /// 法人编码        字符型(3)
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}