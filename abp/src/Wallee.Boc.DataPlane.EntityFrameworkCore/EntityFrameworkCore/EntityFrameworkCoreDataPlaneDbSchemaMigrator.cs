using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wallee.Boc.DataPlane.Data;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore;

public class EntityFrameworkCoreDataPlaneDbSchemaMigrator
    : IDataPlaneDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDataPlaneDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DataPlaneDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DataPlaneDbContext>()
            .Database
            .MigrateAsync();
    }
}
