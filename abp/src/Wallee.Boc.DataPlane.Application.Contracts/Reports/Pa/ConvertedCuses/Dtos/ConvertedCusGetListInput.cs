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
    [CompareTo(nameof(ConvertedCusDto.Cusidt), nameof(ConvertedCusDto.CusName))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}