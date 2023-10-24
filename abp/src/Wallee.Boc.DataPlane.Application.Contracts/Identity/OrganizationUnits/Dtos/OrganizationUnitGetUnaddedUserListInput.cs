using AutoFilterer.Types;
using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos
{
    public class OrganizationUnitGetUnaddedUserListInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
