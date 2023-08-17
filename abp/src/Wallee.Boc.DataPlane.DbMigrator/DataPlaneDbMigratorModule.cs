using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Wallee.Boc.DataPlane.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DataPlaneEntityFrameworkCoreModule),
    typeof(DataPlaneApplicationContractsModule)
    )]
public class DataPlaneDbMigratorModule : AbpModule
{
}
