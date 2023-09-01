using Volo.Abp.Account;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;

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
    typeof(AbpBackgroundJobsAbstractionsModule)
)]
public class DataPlaneApplicationContractsModule : AbpModule
{
    private static readonly OneTimeRunner _oneTimeRunner = new();
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DataPlaneDtoExtensions.Configure();
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        _oneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
                IdentityModuleExtensionConsts.ModuleName,
                IdentityModuleExtensionConsts.EntityNames.OrganizationUnit,
                getApiTypes: new[] { typeof(OrganizationUnitDto) },
                createApiTypes: new[] { typeof(OrganizationUnitCreateDto) },
                updateApiTypes: new[] { typeof(OrganizationUnitUpdateDto) }
            );
        });
    }
}
