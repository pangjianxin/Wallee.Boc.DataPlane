namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;

/// <summary>
/// 对公概况-组织    a18
/// </summary>
public class CcicGeneralOrgKey
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