using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore;

public static class DataPlaneEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        DataPlaneGlobalFeatureConfigurator.Configure();
        DataPlaneModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
                         .MapEfCoreProperty<OrganizationUnit, string>(
                             "OrgNo",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.IsRequired();
                                 propertyBuilder.HasMaxLength(32);
                                 entityBuilder.HasIndex("OrgNo").IsUnique();
                             }
                         );
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE DataPlaneModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:



             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */
        });
    }
}
