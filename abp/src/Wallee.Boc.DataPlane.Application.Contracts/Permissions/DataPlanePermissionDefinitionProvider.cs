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

        //系统设置
        dataPlaneGroup.AddPermission(DataPlanePermissions.Settings.Default, L("Permission:Settings"));

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

        //TDCMP报表
        var tDcmpReports = dataPlaneGroup.AddPermission(DataPlanePermissions.TDcmpReports.Default);
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicBasic, L("Permission:CcicBasic"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicAddress, L("Permission:CcicAddress"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicAntiMoneyLaundering, L("Permission:CcicAntiMoneyLaundering"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicCustomerTypeOrg, L("Permission:CcicCustomerTypeOrg"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicGeneralOrg, L("Permission:CcicGeneralOrg"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicId, L("Permission:CcicId"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicName, L("Permission:CcicName"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicPersonalRelation, L("Permission:CcicPersonalRelation"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicPhone, L("Permission:CcicPhone"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicPractice, L("Permission:CcicPractice"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicRegister, L("Permission:CcicRegister"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicSignOrg, L("Permission:CcicSignOrg"));
        tDcmpReports.AddChild(DataPlanePermissions.TDcmpReports.CcicCustomerType, L("Permission:CcicCustomerType"));

        //TDCMP工作流
        var tDcmpWorkFlowPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.TDcmpWorkFlow.Default, L("Permission:TDcmpWorkFlow"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Create, L("Permission:Create"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Update, L("Permission:Update"));
        tDcmpWorkFlowPermission.AddChild(DataPlanePermissions.TDcmpWorkFlow.Delete, L("Permission:Delete"));

        //字典
        var organizationUnitCoordinatePermission = dataPlaneGroup.AddPermission(DataPlanePermissions.Dictionaries.Default, L("Permission:Dictionaries"));
        organizationUnitCoordinatePermission.AddChild(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate, L("Permission:Dictionaries:OrganizationUnitCoordinates"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
