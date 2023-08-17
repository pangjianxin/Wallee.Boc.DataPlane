using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.Data;

/* This is used if database provider does't define
 * IDataPlaneDbSchemaMigrator implementation.
 */
public class NullDataPlaneDbSchemaMigrator : IDataPlaneDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
