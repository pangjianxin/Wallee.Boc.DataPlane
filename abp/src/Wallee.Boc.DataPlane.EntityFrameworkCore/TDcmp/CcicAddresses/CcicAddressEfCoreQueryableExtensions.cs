using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

public static class CcicAddressEfCoreQueryableExtensions
{
    public static IQueryable<CcicAddress> IncludeDetails(this IQueryable<CcicAddress> queryable, bool include = true)
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
