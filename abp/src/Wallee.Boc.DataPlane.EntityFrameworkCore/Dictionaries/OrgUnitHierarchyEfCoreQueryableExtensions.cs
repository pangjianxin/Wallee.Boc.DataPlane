using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

/// <summary>
/// 机构层级表
/// </summary>
public static class OrgUnitHierarchyEfCoreQueryableExtensions
{
    public static IQueryable<OrgUnitHierarchy> IncludeDetails(this IQueryable<OrgUnitHierarchy> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
