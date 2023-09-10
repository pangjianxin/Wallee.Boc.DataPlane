using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;

/// <summary>
/// 对公名称信息    a22
/// </summary>
public static class CcicPhoneEfCoreQueryableExtensions
{
    public static IQueryable<CcicPhone> IncludeDetails(this IQueryable<CcicPhone> queryable, bool include = true)
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
