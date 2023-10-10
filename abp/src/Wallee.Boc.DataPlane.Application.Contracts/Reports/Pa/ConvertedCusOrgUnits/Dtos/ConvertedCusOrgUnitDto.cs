using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
[Serializable]
public class ConvertedCusOrgUnitDto : EntityDto, IModificationAuditedObject
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

    public Guid? LastModifierId { get; set; }

    public DateTime? LastModificationTime { get; set; }
}