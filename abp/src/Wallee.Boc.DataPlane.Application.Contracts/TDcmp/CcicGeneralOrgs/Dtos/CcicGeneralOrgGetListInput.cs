using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;

[Serializable]
public class CcicGeneralOrgGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [CompareTo(nameof(CcicGeneralOrgDto.CUSNO))]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}