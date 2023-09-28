using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

/// <summary>
/// 客户机构调整
/// </summary>
public static class CusOrgAdjusmentEfCoreQueryableExtensions
{
    public static IQueryable<CusOrgAdjusment> IncludeDetails(this IQueryable<CusOrgAdjusment> queryable, bool include = true)
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
