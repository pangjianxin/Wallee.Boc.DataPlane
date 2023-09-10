namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;

/// <summary>
/// 对公人员关系    a24
/// </summary>
public class CcicPersonalRelationKey
{
    /// <summary>
    ///  客户号. (字符型(10))
    /// </summary>
    public string CUSNO { get; set; } = default!;

    /// <summary>
    ///  关系/角色. (字符型(7))
    /// </summary>
    public string REL_RL { get; set; } = default!;

    /// <summary>
    ///  关系人客户号码. (字符型(10))
    /// </summary>
    public string PRINT_CUSNO_YARD { get; set; } = default!;

    /// <summary>
    ///  法人编码. (字符型(3))
    /// </summary>
    public string LGPER_CODE { get; set; } = default!;
}