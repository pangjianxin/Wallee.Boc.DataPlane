using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;

namespace Wallee.Boc.DataPlane.Permissions;

public class DataPlanePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DataPlanePermissions.GroupName);
        var identityGroup = context.GetGroup(IdentityPermissions.GroupName);
        //组织机构权限
        var organizationUnitsPermission = identityGroup.AddPermission(DataPlanePermissions.OrganizationUnits.Default, L("Permission:Organization"));
        organizationUnitsPermission.AddChild(DataPlanePermissions.OrganizationUnits.Create, L("Permission:Create"));
        organizationUnitsPermission.AddChild(DataPlanePermissions.OrganizationUnits.Update, L("Permission:Update"));
        organizationUnitsPermission.AddChild(DataPlanePermissions.OrganizationUnits.Delete, L("Permission:Delete"));
        organizationUnitsPermission.AddChild(DataPlanePermissions.OrganizationUnits.ManageRoles, L("Permission:OrganizationUnits:ManageRoles"));
        organizationUnitsPermission.AddChild(DataPlanePermissions.OrganizationUnits.ManageUsers, L("Permission:OrganizationUnits:ManageUsers"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
