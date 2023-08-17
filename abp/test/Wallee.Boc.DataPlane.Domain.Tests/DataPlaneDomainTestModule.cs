using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wallee.Boc.DataPlane;

[DependsOn(
    typeof(DataPlaneEntityFrameworkCoreTestModule)
    )]
public class DataPlaneDomainTestModule : AbpModule
{

}
