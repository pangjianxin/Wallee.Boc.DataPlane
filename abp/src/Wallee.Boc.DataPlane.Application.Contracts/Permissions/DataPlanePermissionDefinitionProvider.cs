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

        var ccicAntiMoneyLaunderingPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicAntiMoneyLaundering.Default, L("Permission:CcicAntiMoneyLaundering"));
        ccicAntiMoneyLaunderingPermission.AddChild(DataPlanePermissions.CcicAntiMoneyLaundering.Create, L("Permission:Create"));
        ccicAntiMoneyLaunderingPermission.AddChild(DataPlanePermissions.CcicAntiMoneyLaundering.Update, L("Permission:Update"));
        ccicAntiMoneyLaunderingPermission.AddChild(DataPlanePermissions.CcicAntiMoneyLaundering.Delete, L("Permission:Delete"));

        var ccicCustomerTypeOrgPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicCustomerTypeOrg.Default, L("Permission:CcicCustomerTypeOrg"));
        ccicCustomerTypeOrgPermission.AddChild(DataPlanePermissions.CcicCustomerTypeOrg.Create, L("Permission:Create"));
        ccicCustomerTypeOrgPermission.AddChild(DataPlanePermissions.CcicCustomerTypeOrg.Update, L("Permission:Update"));
        ccicCustomerTypeOrgPermission.AddChild(DataPlanePermissions.CcicCustomerTypeOrg.Delete, L("Permission:Delete"));

        var ccicGeneralOrgPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicGeneralOrg.Default, L("Permission:CcicGeneralOrg"));
        ccicGeneralOrgPermission.AddChild(DataPlanePermissions.CcicGeneralOrg.Create, L("Permission:Create"));
        ccicGeneralOrgPermission.AddChild(DataPlanePermissions.CcicGeneralOrg.Update, L("Permission:Update"));
        ccicGeneralOrgPermission.AddChild(DataPlanePermissions.CcicGeneralOrg.Delete, L("Permission:Delete"));

        var ccicIdPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicId.Default, L("Permission:CcicId"));
        ccicIdPermission.AddChild(DataPlanePermissions.CcicId.Create, L("Permission:Create"));
        ccicIdPermission.AddChild(DataPlanePermissions.CcicId.Update, L("Permission:Update"));
        ccicIdPermission.AddChild(DataPlanePermissions.CcicId.Delete, L("Permission:Delete"));

        var ccicLsolationListPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicLsolationList.Default, L("Permission:CcicLsolationList"));
        ccicLsolationListPermission.AddChild(DataPlanePermissions.CcicLsolationList.Create, L("Permission:Create"));
        ccicLsolationListPermission.AddChild(DataPlanePermissions.CcicLsolationList.Update, L("Permission:Update"));
        ccicLsolationListPermission.AddChild(DataPlanePermissions.CcicLsolationList.Delete, L("Permission:Delete"));

        var ccicNamePermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicName.Default, L("Permission:CcicName"));
        ccicNamePermission.AddChild(DataPlanePermissions.CcicName.Create, L("Permission:Create"));
        ccicNamePermission.AddChild(DataPlanePermissions.CcicName.Update, L("Permission:Update"));
        ccicNamePermission.AddChild(DataPlanePermissions.CcicName.Delete, L("Permission:Delete"));

        var ccicPersonalRelationPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicPersonalRelation.Default, L("Permission:CcicPersonalRelation"));
        ccicPersonalRelationPermission.AddChild(DataPlanePermissions.CcicPersonalRelation.Create, L("Permission:Create"));
        ccicPersonalRelationPermission.AddChild(DataPlanePermissions.CcicPersonalRelation.Update, L("Permission:Update"));
        ccicPersonalRelationPermission.AddChild(DataPlanePermissions.CcicPersonalRelation.Delete, L("Permission:Delete"));

        var ccicPhonePermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicPhone.Default, L("Permission:CcicPhone"));
        ccicPhonePermission.AddChild(DataPlanePermissions.CcicPhone.Create, L("Permission:Create"));
        ccicPhonePermission.AddChild(DataPlanePermissions.CcicPhone.Update, L("Permission:Update"));
        ccicPhonePermission.AddChild(DataPlanePermissions.CcicPhone.Delete, L("Permission:Delete"));

        var ccicPracticePermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicPractice.Default, L("Permission:CcicPractice"));
        ccicPracticePermission.AddChild(DataPlanePermissions.CcicPractice.Create, L("Permission:Create"));
        ccicPracticePermission.AddChild(DataPlanePermissions.CcicPractice.Update, L("Permission:Update"));
        ccicPracticePermission.AddChild(DataPlanePermissions.CcicPractice.Delete, L("Permission:Delete"));

        var ccicRegisterPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicRegister.Default, L("Permission:CcicRegister"));
        ccicRegisterPermission.AddChild(DataPlanePermissions.CcicRegister.Create, L("Permission:Create"));
        ccicRegisterPermission.AddChild(DataPlanePermissions.CcicRegister.Update, L("Permission:Update"));
        ccicRegisterPermission.AddChild(DataPlanePermissions.CcicRegister.Delete, L("Permission:Delete"));

        var ccicSignOrgPermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicSignOrg.Default, L("Permission:CcicSignOrg"));
        ccicSignOrgPermission.AddChild(DataPlanePermissions.CcicSignOrg.Create, L("Permission:Create"));
        ccicSignOrgPermission.AddChild(DataPlanePermissions.CcicSignOrg.Update, L("Permission:Update"));
        ccicSignOrgPermission.AddChild(DataPlanePermissions.CcicSignOrg.Delete, L("Permission:Delete"));

        var ccicCustomerTypePermission = dataPlaneGroup.AddPermission(DataPlanePermissions.CcicCustomerType.Default, L("Permission:CcicCustomerType"));
        ccicCustomerTypePermission.AddChild(DataPlanePermissions.CcicCustomerType.Create, L("Permission:Create"));
        ccicCustomerTypePermission.AddChild(DataPlanePermissions.CcicCustomerType.Update, L("Permission:Update"));
        ccicCustomerTypePermission.AddChild(DataPlanePermissions.CcicCustomerType.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataPlaneResource>(name);
    }
}
