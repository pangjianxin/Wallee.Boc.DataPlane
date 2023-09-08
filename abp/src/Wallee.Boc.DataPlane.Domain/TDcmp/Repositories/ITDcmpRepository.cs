using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.Repositories
{
    public interface ITDcmpRepository<TEntity> : IReadOnlyRepository<TEntity>, ITransientDependency where TEntity : AggregateRoot
    {
        Task UpsertAsync(IEnumerable<TEntity> entities);
    }
}
