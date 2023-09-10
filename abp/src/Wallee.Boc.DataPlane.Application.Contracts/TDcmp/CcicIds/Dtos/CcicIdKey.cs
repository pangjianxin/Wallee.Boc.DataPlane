namespace Wallee.Boc.DataPlane.TDcmp.CcicIds.Dtos;

/// <summary>
/// 对公证件信息    a20
/// </summary>
public class CcicIdKey
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  证件类型. (字符型(2))        证件类型代码  查代码集“其他关联代码集”sheet
    /// </summary>
    public string CRDT_TP { get; set; } = default!;

    /// <summary>
    ///  证件序号. (数值型(3))
    /// </summary>
    public int CRDT_SN { get; set; }

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}