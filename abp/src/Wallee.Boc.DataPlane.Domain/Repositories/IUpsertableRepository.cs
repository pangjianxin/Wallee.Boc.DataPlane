using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Repositories
{
    public interface IUpsertableRepository<TEntity> : IReadOnlyRepository<TEntity>, ITransientDependency where TEntity : BasicAggregateRoot
    {
        Task UpsertAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}
