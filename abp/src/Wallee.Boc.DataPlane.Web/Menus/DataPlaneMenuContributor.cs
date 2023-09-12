using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Localization;
using Wallee.Boc.DataPlane.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.Web.Menus;

public class DataPlaneMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DataPlaneResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DataPlaneMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            //administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        var backgroundJobsMenu = new ApplicationMenuItem(DataPlaneMenus.BackgroundJobs, l["Menu:BackgroundJobs"], icon: "fas fa-tasks", order: 4, requiredPermissionName: DataPlanePermissions.BackgroundJobs.Default);
        backgroundJobsMenu.AddItem(new ApplicationMenuItem(DataPlaneMenus.BackgroundJobs_Index, l["Menu:BackgroundJobs:Index"], icon: "fas fa-tasks", order: 1, url: "/BackgroundJobs/Index", requiredPermissionName: DataPlanePermissions.BackgroundJobs.Default));
        backgroundJobsMenu.AddItem(new ApplicationMenuItem(DataPlaneMenus.BackgroundJobs_Operation, l["Menu:BackgroundJobs:Operation"], icon: "fas fa-cog", order: 2, url: "/BackgroundJobs/Operation", requiredPermissionName: DataPlanePermissions.BackgroundJobs.Default));
        administration.AddItem(backgroundJobsMenu);

        if (await context.IsGrantedAsync(DataPlanePermissions.OrganizationUnits.Default))
        {
            var identity = administration.GetMenuItem(IdentityMenuNames.GroupName);
            identity.AddItem(new ApplicationMenuItem(DataPlaneMenus.OrganizationUnit, l["Menu:OrganizationUnit"], "/Identity/OrganizationUnits"));
        }

        var tDcmpMenu = new ApplicationMenuItem(name: DataPlaneMenus.TDcmp, displayName: l["Menu:TDcmp"], icon: "fas fa-list");

        if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpWorkFlow.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.TDcmp_WorkFlow, l["Menu:TDcmpWorkFlow"], "/TDcmp/WorkFlows/TDcmpWorkFlow", icon: "fas fa-list", order: 1)
            );
        }

        if (await context.IsGrantedAsync(DataPlanePermissions.CcicBasic.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(name: DataPlaneMenus.TDcmp_CcicBasic, displayName: l["Menu:CcicBasic"], url: "/TDcmp/CcicBasics/CcicBasic", icon: "fas fa-list", order: 2)
            );
        }

        if (await context.IsGrantedAsync(DataPlanePermissions.CcicAddress.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.TDcmp_CcicAddress, l["Menu:CcicAddress"], "/TDcmp/CcicAddresses/CcicAddress", icon: "fas fa-list", order: 3)
            );
        }


        if (await context.IsGrantedAsync(DataPlanePermissions.CcicAntiMoneyLaundering.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicAntiMoneyLaundering, l["Menu:CcicAntiMoneyLaundering"], "/TDcmp/CcicAntiMoneyLaunderings/CcicAntiMoneyLaundering", icon: "fas fa-list", order: 4)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicCustomerTypeOrg.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicCustomerTypeOrg, l["Menu:CcicCustomerTypeOrg"], "/TDcmp/CcicCustomerTypeOrgs/CcicCustomerTypeOrg", icon: "fas fa-list", order: 5)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicGeneralOrg.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicGeneralOrg, l["Menu:CcicGeneralOrg"], "/TDcmp/CcicGeneralOrgs/CcicGeneralOrg", icon: "fas fa-list", order: 6)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicId.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicId, l["Menu:CcicId"], "/TDcmp/CcicIds/CcicId", icon: "fas fa-list", order: 7)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicName.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicName, l["Menu:CcicName"], "/TDcmp/CcicNames/CcicName", icon: "fas fa-list", order: 9)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicPersonalRelation.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicPersonalRelation, l["Menu:CcicPersonalRelation"], "/TDcmp/CcicPersonalRelations/CcicPersonalRelation", icon: "fas fa-list", order: 10)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicPhone.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicPhone, l["Menu:CcicPhone"], "/TDcmp/CcicPhones/CcicPhone", icon: "fas fa-list", order: 11)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicPractice.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicPractice, l["Menu:CcicPractice"], "/TDcmp/CcicPractices/CcicPractice", icon: "fas fa-list", order: 12)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicRegister.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicRegister, l["Menu:CcicRegister"], "/TDcmp/CcicRegisters/CcicRegister", icon: "fas fa-list", order: 13)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicSignOrg.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicSignOrg, l["Menu:CcicSignOrg"], "/TDcmp/CcicSignOrgs/CcicSignOrg", icon: "fas fa-list", order: 14)
            );
        }
        if (await context.IsGrantedAsync(DataPlanePermissions.CcicCustomerType.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.CcicCustomerType, l["Menu:CcicCustomerType"], "/TDcmp/CcicCustomerTypes/CcicCustomerType", icon: "fas fa-list", order: 15)
            );
        }

        context.Menu.AddItem(tDcmpMenu);
    }
}
