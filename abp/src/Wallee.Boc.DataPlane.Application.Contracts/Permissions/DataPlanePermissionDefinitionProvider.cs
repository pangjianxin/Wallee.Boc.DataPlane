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

        var ccicBasicPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicBasic.Default, L("Permission:CcicBasic"));
        ccicBasicPermission.AddChild(DataPlanePermissions.CcicBasic.Create, L("Permission:Create"));
        ccicBasicPermission.AddChild(DataPlanePermissions.CcicBasic.Update, L("Permission:Update"));
        ccicBasicPermission.AddChild(DataPlanePermissions.CcicBasic.Delete, L("Permission:Delete"));

        var ccicAddressPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicAddress.Default, L("Permission:CcicAddress"));
        ccicAddressPermission.AddChild(DataPlanePermissions.CcicAddress.Create, L("Permission:Create"));
        ccicAddressPermission.AddChild(DataPlanePermissions.CcicAddress.Update, L("Permission:Update"));
        ccicAddressPermission.AddChild(DataPlanePermissions.CcicAddress.Delete, L("Permission:Delete"));

        var tDcmpWorkFlowPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.TDcmpWorkFlow.Default, L("Permission:TDcmpWorkFlow"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Create, L("Permission:Create"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Update, L("Permission:Update"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
