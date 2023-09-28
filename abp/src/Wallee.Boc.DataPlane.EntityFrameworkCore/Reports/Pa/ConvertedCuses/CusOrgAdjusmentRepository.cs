using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

public class CusOrgAdjusmentRepository : EfCoreRepository<DataPlaneDbContext, CusOrgAdjusment>, ICusOrgAdjusmentRepository
{
    public CusOrgAdjusmentRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public async Task UpsertAsync(IEnumerable<CusOrgAdjusment> convertedCuses)
    {
        await (await GetDbSetAsync()).UpsertRange(convertedCuses)
           .On(it => new { it.Cusidt })
           .WhenMatched((origin, cur) => new CusOrgAdjusment(cur.Cusidt, cur.Orgidt))
           .RunAsync();
    }
    public override async Task<IQueryable<CusOrgAdjusment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}