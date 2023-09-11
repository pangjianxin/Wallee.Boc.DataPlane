using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos
{
    public class OrganizationUnitGetUnaddedRoleListInput : FilterBase, IPagedAndSortedResultRequest
    {
        public string? Filter { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; } = 10;
        public string? Sorting { get; set; }
    }
}
