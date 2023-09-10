using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

/// <summary>
/// 对公客户类别信息    a08
/// </summary>
public static class CcicCustomerTypeEfCoreQueryableExtensions
{
    public static IQueryable<CcicCustomerType> IncludeDetails(this IQueryable<CcicCustomerType> queryable, bool include = true)
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
