using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
[Serializable]
public class ConvertedCusOrgUnitDto : EntityDto
{
    public string? ParentName { get; set; }
    public string? ParentIdentity { get; set; }
    public string OrgName { get; set; } = default!;
    public string OrgIdentity { get; set; } = default!;
    public decimal FirstLevel { get; set; }
    public decimal SecondLevel { get; set; }
    public decimal ThirdLevel { get; set; }
    public decimal FourthLevel { get; set; }
    public decimal FifthLevel { get; set; }
    public decimal SixthLevel { get; set; }
    public DateTime DataDate { get; set; }
}