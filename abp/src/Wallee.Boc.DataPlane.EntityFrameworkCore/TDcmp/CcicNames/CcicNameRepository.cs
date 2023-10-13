using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;

public class CcicNameRepository : UpsertableEfCoreRepository<CcicName>, ICcicNameRepository
{
    public CcicNameRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public override async Task<IQueryable<CcicName>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}