using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;

public class CcicPhoneRepository : UpsertableEfCoreRepository<CcicPhone>, ICcicPhoneRepository
{
    public CcicPhoneRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicPhone>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}