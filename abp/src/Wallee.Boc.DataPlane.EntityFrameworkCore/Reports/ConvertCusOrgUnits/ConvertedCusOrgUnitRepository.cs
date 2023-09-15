using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

public class ConvertedCusOrgUnitRepository : EfCoreRepository<DataPlaneDbContext, ConvertedCusOrgUnit, Guid>, IConvertedCusOrgUnitRepository
{
    public ConvertedCusOrgUnitRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ConvertedCusOrgUnit>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}