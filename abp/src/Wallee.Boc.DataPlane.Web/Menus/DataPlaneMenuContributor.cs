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

        if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpWorkFlow.Default))
        {
            tDcmpMenu.AddItem(
                new ApplicationMenuItem(DataPlaneMenus.TDcmp_WorkFlow, l["Menu:TDcmpWorkFlow"], "/TDcmp/WorkFlows/TDcmpWorkFlow", icon: "fas fa-list", order: 1)
            );
        }

        context.Menu.AddItem(tDcmpMenu);

    }
}
