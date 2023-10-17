using System;
using System.Collections.Generic;
using Volo.Abp.Caching;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches
{
    [CacheName("org-unit-hierarchy")]
    public class OrganizationUnitCache
    {
        public List<OrganizationUnitDto> Items { get; set; } = default!;
    }
}