using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;

public class CcicAntiMoneyLaunderingRepository : EfCoreRepository<DataPlaneDbContext, CcicAntiMoneyLaundering>, ICcicAntiMoneyLaunderingRepository
{
    public CcicAntiMoneyLaunderingRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }



    public async Task UpsertAsync(IEnumerable<CcicAntiMoneyLaundering> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {

        DbContext dbContext = await GetDbContextAsync();

        var entityArray = entities.ToArray();

        foreach (var entity in entityArray)
        {
            CheckAndSetId(entity);
        }

        await dbContext.BulkInsertOrUpdateAsync(entityArray, cancellationToken: cancellationToken);

        if (autoSave)
        {
            await dbContext.BulkSaveChangesAsync();
        }
    }

    public override async Task<IQueryable<CcicAntiMoneyLaundering>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}