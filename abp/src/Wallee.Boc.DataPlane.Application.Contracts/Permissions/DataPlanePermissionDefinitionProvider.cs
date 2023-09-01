using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;

namespace Wallee.Boc.DataPlane.Permissions;

public class DataPlanePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var dataPlaneGroup = context.AddGroup(DataPlanePermissions.GroupName);
        var identityGroup = context.GetGroup(IdentityPermissions.GroupName);

        //后台任务
        var backgroundJobs = dataPlaneGroup.AddPermission(DataPlanePermissions.BackgroundJobs.Default, L("Permission:BackgroundJobs"));
        backgroundJobs.AddChild(DataPlanePermissions.BackgroundJobs.Create, L("Permission:Create"));
        backgroundJobs.AddChild(DataPlanePermissions.BackgroundJobs.Update, L("Permission:Update"));
        backgroundJobs.AddChild(DataPlanePermissions.BackgroundJobs.Delete, L("Permission:Delete"));
        backgroundJobs.AddChild(DataPlanePermissions.BackgroundJobs.Operation, L("Permission:BackgroundJobs:Operation"));

        //组织机构权限
        var organizationUnits = identityGroup.AddPermission(DataPlanePermissions.OrganizationUnits.Default, L("Permission:Organization"));
        organizationUnits.AddChild(DataPlanePermissions.OrganizationUnits.Create, L("Permission:Create"));
        organizationUnits.AddChild(DataPlanePermissions.OrganizationUnits.Update, L("Permission:Update"));
        organizationUnits.AddChild(DataPlanePermissions.OrganizationUnits.Delete, L("Permission:Delete"));
        organizationUnits.AddChild(DataPlanePermissions.OrganizationUnits.ManageRoles, L("Permission:OrganizationUnits:ManageRoles"));
        organizationUnits.AddChild(DataPlanePermissions.OrganizationUnits.ManageUsers, L("Permission:OrganizationUnits:ManageUsers"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
