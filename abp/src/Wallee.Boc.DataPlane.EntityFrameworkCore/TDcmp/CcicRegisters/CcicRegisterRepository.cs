using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

public class CcicRegisterRepository : UpsertableEfCoreRepository<CcicRegister>, ICcicRegisterRepository
{
    public CcicRegisterRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicRegister>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}