using Volo.Abp.Modularity;

namespace Wallee.Boc.DataPlane;

[DependsOn(
    typeof(DataPlaneApplicationModule),
    typeof(DataPlaneDomainTestModule)
    )]
public class DataPlaneApplicationTestModule : AbpModule
{

}
