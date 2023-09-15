using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;

[Serializable]
public class ConvertedCusOrgUnitGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    [CompareTo(nameof(ConvertedCusOrgUnitDto.Label), nameof(ConvertedCusOrgUnitDto.UpOrgidt), nameof(ConvertedCusOrgUnitDto.Orgidt))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}