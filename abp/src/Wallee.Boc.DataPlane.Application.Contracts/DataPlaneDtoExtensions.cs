using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane;

public static class DataPlaneDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
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
