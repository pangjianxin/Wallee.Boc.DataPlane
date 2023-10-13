using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Repositories
{
    public abstract class UpsertableEfCoreRepository<TEntity> : EfCoreRepository<DataPlaneDbContext, TEntity> where TEntity : class, IEntity
    {
        protected UpsertableEfCoreRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async virtual Task UpsertAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
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

    }
}
