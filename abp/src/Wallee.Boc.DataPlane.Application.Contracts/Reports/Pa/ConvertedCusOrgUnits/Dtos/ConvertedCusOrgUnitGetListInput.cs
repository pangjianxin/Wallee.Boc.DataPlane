using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;

[Serializable]
public class ConvertedCusOrgUnitGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    [CompareTo(nameof(ConvertedCusOrgUnitDto.ParentName), nameof(ConvertedCusOrgUnitDto.ParentIdentity), nameof(ConvertedCusOrgUnitDto.OrgIdentity))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public DateTime? DataDate { get; set; }
    public string? Sorting { get; set; }
}