using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;

/// <summary>
/// 对公人员关系    a24
/// </summary>
public static class CcicPersonalRelationEfCoreQueryableExtensions
{
    public static IQueryable<CcicPersonalRelation> IncludeDetails(this IQueryable<CcicPersonalRelation> queryable, bool include = true)
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
