using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;

public class CcicGeneralOrgRepository : UpsertableEfCoreRepository<CcicGeneralOrg>, ICcicGeneralOrgRepository
{
    public CcicGeneralOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicGeneralOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}