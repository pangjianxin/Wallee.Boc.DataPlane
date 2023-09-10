using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;

/// <summary>
/// 对公概况-组织    a18
/// </summary>
public static class CcicGeneralOrgEfCoreQueryableExtensions
{
    public static IQueryable<CcicGeneralOrg> IncludeDetails(this IQueryable<CcicGeneralOrg> queryable, bool include = true)
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
