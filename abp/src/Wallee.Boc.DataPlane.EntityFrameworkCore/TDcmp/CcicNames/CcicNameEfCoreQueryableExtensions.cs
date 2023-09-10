using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;

/// <summary>
/// 对公名称信息    a22
/// </summary>
public static class CcicNameEfCoreQueryableExtensions
{
    public static IQueryable<CcicName> IncludeDetails(this IQueryable<CcicName> queryable, bool include = true)
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
