using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;

[Serializable]
public class CcicLsolationListGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [CompareTo(nameof(CcicLsolationListDto.CUSNO))]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}