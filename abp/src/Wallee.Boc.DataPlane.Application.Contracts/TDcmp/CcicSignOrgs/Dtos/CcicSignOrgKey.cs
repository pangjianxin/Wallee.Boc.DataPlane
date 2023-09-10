using System;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;

/// <summary>
/// 对公重要标志信息-组织    a35
/// </summary>
public class CcicSignOrgKey
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