using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

public class CusOrgAdjusmentRepository : EfCoreRepository<DataPlaneDbContext, CusOrgAdjusment>, ICusOrgAdjusmentRepository
{
    private readonly IClock _clock;

    public CusOrgAdjusmentRepository(
        IDbContextProvider<DataPlaneDbContext> dbContextProvider,
        IClock clock) : base(dbContextProvider)
    {
        _clock = clock;
    }
    public async Task UpsertAsync(IEnumerable<CusOrgAdjusment> convertedCuses)
    {
        await (await GetDbSetAsync()).UpsertRange(convertedCuses)
           .On(it => new { it.Cusidt })
           .WhenMatched((origin, cur) => new CusOrgAdjusment
           {
               Cusidt = cur.Cusidt,
               Orgidt = cur.Orgidt,
               LastModificationTime = _clock.Now
           })
           .RunAsync();
    }
    public override async Task<IQueryable<CusOrgAdjusment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}