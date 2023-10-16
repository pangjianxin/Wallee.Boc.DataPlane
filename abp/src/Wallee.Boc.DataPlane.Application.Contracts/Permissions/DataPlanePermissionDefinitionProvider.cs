using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;

namespace Wallee.Boc.DataPlane.Permissions;

public class DataPlanePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var dataPlaneGroup = context.AddGroup(DataPlanePermissions.GroupName, L("DataPlane"));
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
        var tDcmpReportsPermissions = dataPlaneGroup.AddPermission(DataPlanePermissions.TDcmpReports.Default, L("Permission:TDcmpReports"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicBasic, L("Permission:TDcmpReports:CcicBasic"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicAddress, L("Permission:TDcmpReports:CcicAddress"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicAntiMoneyLaundering, L("Permission:TDcmpReports:CcicAntiMoneyLaundering"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicCustomerTypeOrg, L("Permission:TDcmpReports:CcicCustomerTypeOrg"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicGeneralOrg, L("Permission:TDcmpReports:CcicGeneralOrg"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicId, L("Permission:TDcmpReports:CcicId"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicName, L("Permission:TDcmpReports:CcicName"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicPersonalRelation, L("Permission:TDcmpReports:CcicPersonalRelation"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicPhone, L("Permission:TDcmpReports:CcicPhone"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicPractice, L("Permission:TDcmpReports:CcicPractice"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicRegister, L("Permission:TDcmpReports:CcicRegister"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicSignOrg, L("Permission:TDcmpReports:CcicSignOrg"));
        tDcmpReportsPermissions.AddChild(DataPlanePermissions.TDcmpReports.CcicCustomerType, L("Permission:TDcmpReports:CcicCustomerType"));

        //工作流
        var workFlowsPermissions = dataPlaneGroup.AddPermission(DataPlanePermissions.WorkFlows.Default, L("Permission:WorkFlows"));
        workFlowsPermissions.AddChild(DataPlanePermissions.WorkFlows.CcicCusInfo, L("Permission:WorkFlows:CcicCusInfo"));

        //字典
        var dictionariesPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.Dictionaries.Default, L("Permission:Dictionaries"));
        dictionariesPermission.AddChild(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate, L("Permission:Dictionaries:OrganizationUnitCoordinates"));
        dictionariesPermission.AddChild(DataPlanePermissions.Dictionaries.OrgUnitHierarchy, L("Permission:Dictionaries:OrgUnitHierarchy"));

        //系统报表
        var systemReportsPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.Reports.Defaults, L("Permission:Reports"));
        systemReportsPermission.AddChild(DataPlanePermissions.Reports.ConvertedCusOrgUnit, L("Permission:Reports:ConvertedCusOrgUnit"));
        systemReportsPermission.AddChild(DataPlanePermissions.Reports.ConvertedCus, L("Permission:Reports:ConvertedCus"));

        var dashboardPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.Dashboard.Default, L("Permission:Dashboad"));
        dashboardPermission.AddChild(DataPlanePermissions.Dashboard.ConvertedCusOrgUnit, L("Permission:Dashboard:ConvertedCusOrgUnit"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
