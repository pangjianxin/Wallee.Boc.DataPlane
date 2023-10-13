using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

public class CcicCustomerTypeRepository : UpsertableEfCoreRepository<CcicCustomerType>, ICcicCustomerTypeRepository
{
    public CcicCustomerTypeRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }


    public override async Task<IQueryable<CcicCustomerType>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}