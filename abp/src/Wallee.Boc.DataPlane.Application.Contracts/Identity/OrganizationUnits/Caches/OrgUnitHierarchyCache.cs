using System.Collections.Generic;
using Volo.Abp.Caching;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches
{
    [CacheName("org-unit-hierarchy")]
    public class OrgUnitHierarchyCache
    {
        public List<OrgUnitHierarchyCacheItem> Items { get; set; } = default!;
    }

    public class OrgUnitHierarchyCacheItem
    {
        public string Orgidt { get; set; } = default!;
        public string UpOrgidt { get; set; } = default!;
    }
}