using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;

/// <summary>
/// 对公运营信息    a26
/// </summary>
public static class CcicPracticeEfCoreQueryableExtensions
{
    public static IQueryable<CcicPractice> IncludeDetails(this IQueryable<CcicPractice> queryable, bool include = true)
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
