namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;

/// <summary>
/// 对公运营信息    a26
/// </summary>
public class CcicPracticeKey
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  经营信息序号. (数值型(5))
    /// </summary>
    public int OPRT_INF_SN { get; set; }

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}