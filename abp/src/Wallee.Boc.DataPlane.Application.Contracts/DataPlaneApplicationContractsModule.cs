using Volo.Abp.Account;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane;

[DependsOn(
    typeof(DataPlaneDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpBackgroundJobsAbstractionsModule),
    typeof(AbpCachingModule)
)]
public class DataPlaneApplicationContractsModule : AbpModule
{
    private static readonly OneTimeRunner _oneTimeRunner = new();
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DataPlaneDtoExtensions.Configure();
    }
}
