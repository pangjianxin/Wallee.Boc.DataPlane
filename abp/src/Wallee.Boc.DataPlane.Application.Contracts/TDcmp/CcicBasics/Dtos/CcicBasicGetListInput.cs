using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

[Serializable]
public class CcicBasicGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [CompareTo(nameof(CcicBasicDto.CUSNO), nameof(CcicBasicDto.LGPER_CODE))]
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    public string? Filter { get; set; }

    public int SkipCount { get; set; }

    public int MaxResultCount { get; set; }

    public string? Sorting { get; set; }
}