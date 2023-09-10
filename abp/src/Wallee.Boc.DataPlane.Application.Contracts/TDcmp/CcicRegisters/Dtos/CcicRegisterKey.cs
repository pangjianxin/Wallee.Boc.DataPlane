namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;

/// <summary>
/// 对公注册信息    a28
/// </summary>
public class CcicRegisterKey
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