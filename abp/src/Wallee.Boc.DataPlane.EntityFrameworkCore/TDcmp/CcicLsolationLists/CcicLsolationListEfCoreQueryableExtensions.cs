using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;

/// <summary>
/// 对公隔离清单信息    a82
/// </summary>
public static class CcicLsolationListEfCoreQueryableExtensions
{
    public static IQueryable<CcicLsolationList> IncludeDetails(this IQueryable<CcicLsolationList> queryable, bool include = true)
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
