using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

[Serializable]
public class ConvertedCusGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(StringFilterOption.Contains)]
    [CompareTo(nameof(ConvertedCusDto.CusIdentity))]
    public string? Filter { get; set; }

    [CompareTo(nameof(ConvertedCusDto.DataDate))]
    public DateTime? DataDate { get; set; }

    public string? OrgIdentity { get; set; }

    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}