using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
[Serializable]
public class ConvertedCusOrgUnitDto : AuditedEntityDto<Guid>
{
    public string Label { get; set; } = default!;

    public string UpOrgidt { get; set; } = default!;

    public string Orgidt { get; set; } = default!;

    public decimal FirstLevel { get; set; }

    public decimal SecondLevel { get; set; }

    public decimal ThirdLevel { get; set; }

    public decimal FourthLevel { get; set; }

    public decimal FifthLevel { get; set; }

    public decimal SixthLevel { get; set; }
    public DateTime DataDate { get; set; }
}