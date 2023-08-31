using Volo.Abp.Modularity;

namespace Wallee.Boc.DataPlane.Background
{
    [DependsOn(typeof(DataPlaneDomainModule))]
    public class DataPlaneBackgroundModule : AbpModule
    {

    }
}