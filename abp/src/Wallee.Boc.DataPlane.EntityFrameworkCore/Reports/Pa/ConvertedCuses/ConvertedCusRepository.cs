using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

public class ConvertedCusRepository : EfCoreRepository<DataPlaneDbContext, ConvertedCus>, IConvertedCusRepository
{
    public ConvertedCusRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<ConvertedCus> convertedCuses)
    {
        await (await GetDbSetAsync()).UpsertRange(convertedCuses)
           .On(it => new { it.DataDate, it.Cusidt })
           .WhenMatched((origin, cur) => new ConvertedCus
           {
               DataDate = cur.DataDate,
               Cusidt = cur.Cusidt,
               CusName = cur.CusName,
               DepYavBal = cur.DepYavBal,
               DepCurBal = cur.DepCurBal,
               Orgidt = cur.Orgidt,
               OrgName = cur.OrgName
           })
           .RunAsync();
    }

    public override async Task<IQueryable<ConvertedCus>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}