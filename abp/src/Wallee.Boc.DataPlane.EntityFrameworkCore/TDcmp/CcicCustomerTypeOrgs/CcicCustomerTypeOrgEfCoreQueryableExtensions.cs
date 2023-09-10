using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;

/// <summary>
/// 对公客户类别信息-组织    a09
/// </summary>
public static class CcicCustomerTypeOrgEfCoreQueryableExtensions
{
    public static IQueryable<CcicCustomerTypeOrg> IncludeDetails(this IQueryable<CcicCustomerTypeOrg> queryable, bool include = true)
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
