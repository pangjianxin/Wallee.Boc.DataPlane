using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;

/// <summary>
/// 信息管理平台工作流
/// </summary>
public static class TDcmpWorkFlowEfCoreQueryableExtensions
{
    public static IQueryable<TDcmpWorkFlow> IncludeDetails(this IQueryable<TDcmpWorkFlow> queryable, bool include = true)
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
