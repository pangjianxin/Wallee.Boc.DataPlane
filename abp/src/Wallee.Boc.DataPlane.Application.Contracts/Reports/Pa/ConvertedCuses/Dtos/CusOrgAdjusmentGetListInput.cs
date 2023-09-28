using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

[Serializable]
public class CusOrgAdjusmentGetListInput : FilterBase, IPagedAndSortedResultRequest
{
    [StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Contains)]
    [CompareTo(nameof(CusOrgAdjusmentDto.Cusidt))]
    public string? Filter { get; set; }
    public int SkipCount { get; set; }
    public int MaxResultCount { get; set; }
    public string? Sorting { get; set; }
}