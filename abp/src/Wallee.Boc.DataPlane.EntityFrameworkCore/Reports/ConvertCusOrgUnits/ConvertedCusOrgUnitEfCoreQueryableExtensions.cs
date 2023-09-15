using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
public static class ConvertedCusOrgUnitEfCoreQueryableExtensions
{
    public static IQueryable<ConvertedCusOrgUnit> IncludeDetails(this IQueryable<ConvertedCusOrgUnit> queryable, bool include = true)
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
