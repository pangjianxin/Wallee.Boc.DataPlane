using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

public class CcicAddressRepository : EfCoreRepository<DataPlaneDbContext, CcicAddress>, ICcicAddressRepository
{
    public CcicAddressRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicAddress>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    public async Task ExecuteSqlRawAsync(string sql)
    {
        var dbContext = await GetDbContextAsync();
        var str = dbContext.Database.GenerateCreateScript();
        await dbContext.Database.ExecuteSqlRawAsync(sql);
    }
}