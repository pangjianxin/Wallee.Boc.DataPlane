using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;

public class CcicBasicRepository : UpsertableEfCoreRepository<CcicBasic>, ICcicBasicRepository
{
    public CcicBasicRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicBasic>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}