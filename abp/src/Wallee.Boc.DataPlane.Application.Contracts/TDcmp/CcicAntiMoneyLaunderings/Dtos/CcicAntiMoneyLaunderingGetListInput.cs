using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;

[Serializable]
public class CcicAntiMoneyLaunderingGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [CompareTo(nameof(CcicAntiMoneyLaunderingDto.CUSNO))]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}