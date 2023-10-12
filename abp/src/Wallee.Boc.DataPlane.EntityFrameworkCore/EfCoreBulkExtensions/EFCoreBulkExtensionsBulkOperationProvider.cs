using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.EfCoreBulkExtensions
{
    [ExposeServices(typeof(IEfCoreBulkOperationProvider))]
    public class EFCoreBulkExtensionsBulkOperationProvider : IEfCoreBulkOperationProvider, ITransientDependency
    {
        private readonly IEntityChangeEventHelper _entityChangeEventHelper;

        public EFCoreBulkExtensionsBulkOperationProvider(IEntityChangeEventHelper entityChangeEventHelper)
        {
            _entityChangeEventHelper = entityChangeEventHelper;
        }

        public async Task InsertManyAsync<TDbContext, TEntity>(
            IEfCoreRepository<TEntity> repository,
            IEnumerable<TEntity> entities,
            bool autoSave,
            CancellationToken cancellationToken)
            where TDbContext : IEfCoreDbContext
            where TEntity : class, IEntity
        {
            DbContext context = await repository.GetDbContextAsync();

            List<TEntity> entityList = entities.ToList();

            await context.BulkInsertAsync(entityList, cancellationToken: cancellationToken);

            if (autoSave)
            {
                await context.BulkSaveChangesAsync(cancellationToken: cancellationToken);
            }

            // generate create events
            foreach (TEntity entity in entityList)
            {
                _entityChangeEventHelper.PublishEntityCreatedEvent(entity);
            }
        }

        public async Task UpdateManyAsync<TDbContext, TEntity>(
            IEfCoreRepository<TEntity> repository,
            IEnumerable<TEntity> entities,
            bool autoSave,
            CancellationToken cancellationToken)
            where TDbContext : IEfCoreDbContext
            where TEntity : class, IEntity
        {
            DbContext context = await repository.GetDbContextAsync();

            List<TEntity> entityList = entities.ToList();

            await context.BulkUpdateAsync(entityList, cancellationToken: cancellationToken);

            if (autoSave)
            {
                await context.BulkSaveChangesAsync(cancellationToken: cancellationToken);
            }

            // generate update events
            foreach (TEntity entity in entityList)
            {
                _entityChangeEventHelper.PublishEntityUpdatedEvent(entity);
            }
        }

        public async Task DeleteManyAsync<TDbContext, TEntity>(
            IEfCoreRepository<TEntity> repository,
            IEnumerable<TEntity> entities,
            bool autoSave,
            CancellationToken cancellationToken)
            where TDbContext : IEfCoreDbContext
            where TEntity : class, IEntity
        {
            DbContext context = await repository.GetDbContextAsync();

            List<TEntity> entityList = entities.ToList();

            await context.BulkDeleteAsync(entityList, cancellationToken: cancellationToken);

            if (autoSave)
            {
                await context.BulkSaveChangesAsync(cancellationToken: cancellationToken);
            }

            // generate delete events
            foreach (TEntity entity in entityList)
            {
                _entityChangeEventHelper.PublishEntityDeletedEvent(entity);
            }
        }
    }
}
