using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class OrgUnitHierarchyGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    [CompareTo(nameof(OrgUnitHierarchyDto.Name), nameof(OrgUnitHierarchyDto.OrgIdentity))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}