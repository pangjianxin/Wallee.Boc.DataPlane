using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

/// <summary>
/// 对公重要标志信息-组织    a35
/// </summary>
public static class CcicSignOrgEfCoreQueryableExtensions
{
    public static IQueryable<CcicSignOrg> IncludeDetails(this IQueryable<CcicSignOrg> queryable, bool include = true)
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
