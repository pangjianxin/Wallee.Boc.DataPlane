using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

/// <summary>
/// 折效客户明细
/// </summary>
public static class ConvertedCusEfCoreQueryableExtensions
{
    public static IQueryable<ConvertedCus> IncludeDetails(this IQueryable<ConvertedCus> queryable, bool include = true)
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
