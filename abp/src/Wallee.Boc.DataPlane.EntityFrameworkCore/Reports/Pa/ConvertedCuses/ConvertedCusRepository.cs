using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class ConvertedCusRepository : EfCoreRepository<DataPlaneDbContext, ConvertedCus>, IConvertedCusRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
{
    public ConvertedCusRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider, IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }

    public IClock Clock { get; }

    public async Task UpsertAsync(IEnumerable<ConvertedCus> convertedCuses)
    {
        var dbContext = await GetDbContextAsync();
        await dbContext.BulkInsertOrUpdateAsync(convertedCuses);
        await dbContext.SaveChangesAsync();
        //await (await GetDbSetAsync()).UpsertRange(convertedCuses)
        //   .On(it => new { it.DataDate, it.Cusidt })
        //   .WhenMatched((origin, cur) => new ConvertedCus
        //   {
        //       DataDate = cur.DataDate,
        //       Cusidt = cur.Cusidt,
        //       CusName = cur.CusName,
        //       DepYavBal = cur.DepYavBal,
        //       DepCurBal = cur.DepCurBal,
        //       Orgidt = cur.Orgidt,
        //       OrgName = cur.OrgName,
        //       LastModificationTime = Clock.Now
        //   })
        //   .RunAsync();
    }

    public override async Task<IQueryable<ConvertedCus>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}