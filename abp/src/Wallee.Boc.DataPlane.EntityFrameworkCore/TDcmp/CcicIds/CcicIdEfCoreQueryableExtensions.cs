using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;

/// <summary>
/// 对公证件信息    a20
/// </summary>
public static class CcicIdEfCoreQueryableExtensions
{
    public static IQueryable<CcicId> IncludeDetails(this IQueryable<CcicId> queryable, bool include = true)
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
