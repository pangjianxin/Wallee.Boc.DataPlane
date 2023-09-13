using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

public class OrganizationUnitCoordinateRepository : EfCoreRepository<DataPlaneDbContext, OrganizationUnitCoordinate, Guid>, IOrganizationUnitCoordinateRepository
{
    public OrganizationUnitCoordinateRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrganizationUnitCoordinate>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}