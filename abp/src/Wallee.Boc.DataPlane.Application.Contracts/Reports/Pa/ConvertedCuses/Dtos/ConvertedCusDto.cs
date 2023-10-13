using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

/// <summary>
/// 折效客户明细
/// </summary>
[Serializable]
public class ConvertedCusDto : EntityDto
{
    /// <summary>
    /// 数据日期
    /// </summary>
    public DateTime DataDate { get; set; }
    /// <summary>
    /// 客户号
    /// </summary>
    public string Cusidt { get; set; } = default!;
    /// <summary>
    /// 客户名称
    /// </summary>
    public string CusName { get; set; } = default!;
    /// <summary>
    /// 存款年日均
    /// </summary>
    public decimal DepYavBal { get; set; }
    /// <summary>
    /// 存款当前余额
    /// </summary>
    public decimal DepCurBal { get; set; }
    /// <summary>
    /// 所属机构
    /// </summary>
    public string Orgidt { get; set; } = default!;
    /// <summary>
    /// 所属机构名称
    /// </summary>
    public string OrgName { get; set; } = default!;
}