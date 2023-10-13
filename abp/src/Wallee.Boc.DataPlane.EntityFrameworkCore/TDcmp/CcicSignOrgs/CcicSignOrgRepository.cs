using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

public class CcicSignOrgRepository : UpsertableEfCoreRepository<CcicSignOrg>, ICcicSignOrgRepository
{
    public CcicSignOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicSignOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}