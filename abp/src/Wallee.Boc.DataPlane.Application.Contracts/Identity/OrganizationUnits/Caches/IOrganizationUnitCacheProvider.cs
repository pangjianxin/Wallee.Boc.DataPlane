using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches
{
    public interface IOrganizationUnitCacheProvider
    {
        Task<OrganizationUnitCache> GetOrAddOrganizationUnitAsync();
        Task<List<OrganizationUnitDto>> GetVisibleOrganizationUnitsAsync(string? orgCode, bool containsParents = false);
        Task RefreshAsync();
    }
}
