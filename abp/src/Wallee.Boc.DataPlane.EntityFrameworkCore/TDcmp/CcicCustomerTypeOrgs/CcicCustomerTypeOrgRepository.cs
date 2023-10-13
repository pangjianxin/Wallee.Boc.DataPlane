using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;

public class CcicCustomerTypeOrgRepository : UpsertableEfCoreRepository<CcicCustomerTypeOrg>, ICcicCustomerTypeOrgRepository
{
    public CcicCustomerTypeOrgRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicCustomerTypeOrg>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}