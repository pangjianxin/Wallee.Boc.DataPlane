using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

public static class OrganizationUnitCoordinateEfCoreQueryableExtensions
{
    public static IQueryable<OrganizationUnitCoordinate> IncludeDetails(this IQueryable<OrganizationUnitCoordinate> queryable, bool include = true)
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
