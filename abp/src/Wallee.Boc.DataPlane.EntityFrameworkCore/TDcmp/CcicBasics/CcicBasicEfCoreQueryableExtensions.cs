using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;

/// <summary>
/// 对公客户基础信息
/// </summary>
public static class CcicBasicEfCoreQueryableExtensions
{
    public static IQueryable<CcicBasic> IncludeDetails(this IQueryable<CcicBasic> queryable, bool include = true)
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
