using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;

[Serializable]
public class CcicCustomerTypeGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [CompareTo(nameof(CcicCustomerTypeDto.CUSNO))]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}