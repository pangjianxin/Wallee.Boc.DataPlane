using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;

public class CcicIdRepository : UpsertableEfCoreRepository<CcicId>, ICcicIdRepository
{
    public CcicIdRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicId>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}