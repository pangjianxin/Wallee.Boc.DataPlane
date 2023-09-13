using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class OrganizationUnitCoordinateGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    [CompareTo(nameof(OrganizationUnitCoordinateDto.OrgName), nameof(OrganizationUnitCoordinateDto.OrgNo))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}