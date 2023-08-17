using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wallee.Boc.DataPlane.Permissions;

public class DataPlanePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DataPlanePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DataPlanePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
