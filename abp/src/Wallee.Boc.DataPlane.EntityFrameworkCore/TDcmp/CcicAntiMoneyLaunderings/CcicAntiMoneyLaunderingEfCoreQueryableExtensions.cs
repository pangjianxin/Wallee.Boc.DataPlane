using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;

/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
public static class CcicAntiMoneyLaunderingEfCoreQueryableExtensions
{
    public static IQueryable<CcicAntiMoneyLaundering> IncludeDetails(this IQueryable<CcicAntiMoneyLaundering> queryable, bool include = true)
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
