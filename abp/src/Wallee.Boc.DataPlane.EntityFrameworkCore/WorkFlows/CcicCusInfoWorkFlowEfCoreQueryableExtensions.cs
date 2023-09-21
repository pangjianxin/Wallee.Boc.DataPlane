using System.Linq;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.WorkFlows;

/// <summary>
/// 信息管理平台工作流
/// </summary>
public static class CcicCusInfoWorkFlowEfCoreQueryableExtensions
{
    public static IQueryable<CcicCusInfoWorkFlow> IncludeDetails(this IQueryable<CcicCusInfoWorkFlow> queryable, bool include = true)
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
