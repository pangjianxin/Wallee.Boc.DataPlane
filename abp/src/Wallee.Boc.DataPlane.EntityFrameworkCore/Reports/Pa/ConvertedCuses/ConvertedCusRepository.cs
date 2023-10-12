using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

#pragma warning disable CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
public class ConvertedCusRepository : EfCoreRepository<DataPlaneDbContext, ConvertedCus>, IConvertedCusRepository
#pragma warning restore CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
{
    public ConvertedCusRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider, IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }

    public IClock Clock { get; }

    public async Task UpsertAsync(IEnumerable<ConvertedCus> convertedCuses, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        DbContext dbContext = await GetDbContextAsync();

        var entityArray = convertedCuses.ToArray();

        foreach (var entity in entityArray)
        {
            CheckAndSetId(entity);
        }

        await dbContext.BulkInsertOrUpdateAsync(entityArray, cancellationToken: cancellationToken);

        if (autoSave)
        {
            await dbContext.BulkSaveChangesAsync();
        }
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