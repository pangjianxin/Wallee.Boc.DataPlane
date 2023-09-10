using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

/// <summary>
/// 对公注册信息    a28
/// </summary>
public static class CcicRegisterEfCoreQueryableExtensions
{
    public static IQueryable<CcicRegister> IncludeDetails(this IQueryable<CcicRegister> queryable, bool include = true)
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
