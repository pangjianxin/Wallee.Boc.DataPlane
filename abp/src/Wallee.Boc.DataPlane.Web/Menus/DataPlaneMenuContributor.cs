using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Localization;
using Wallee.Boc.DataPlane.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Wallee.Boc.DataPlane.Permissions;
using Microsoft.Extensions.Localization;

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
        var l = context.GetLocalizer<DataPlaneResource>();
        //administration
        await SetAdministrationMenuAsync(context, l);
        //home
        context.Menu.Items.Insert(0, new ApplicationMenuItem(DataPlaneMenus.Home, l["Menu:Home"], "~/", icon: "fas fa-home", order: 0));
        //dashboard
        context.Menu.AddItem(new ApplicationMenuItem(DataPlaneMenus.Dashboard, l["Menu:Dashboard"], "/Dashboard", icon: "fas fa-tachometer-alt", order: 1));

        //TDCMP
        if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.Default))
        {
            var tDcmpMenu = new ApplicationMenuItem(name: DataPlaneMenus.TDcmp, displayName: l["Menu:TDcmp"], icon: "fas fa-list", order: 2);

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicBasic))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(name: DataPlaneMenus.TDcmp_CcicBasic, displayName: l["Menu:TDcmpReports:CcicBasic"], url: "/TDcmp/CcicBasics/CcicBasic", icon: "fas fa-list", order: 2)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicAddress))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.TDcmp_CcicAddress, l["Menu:TDcmpReports:CcicAddress"], "/TDcmp/CcicAddresses/CcicAddress", icon: "fas fa-list", order: 3)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicAntiMoneyLaundering))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicAntiMoneyLaundering, l["Menu:TDcmpReports:CcicAntiMoneyLaundering"], "/TDcmp/CcicAntiMoneyLaunderings/CcicAntiMoneyLaundering", icon: "fas fa-list", order: 4)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicCustomerTypeOrg))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicCustomerTypeOrg, l["Menu:TDcmpReports:CcicCustomerTypeOrg"], "/TDcmp/CcicCustomerTypeOrgs/CcicCustomerTypeOrg", icon: "fas fa-list", order: 5)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicGeneralOrg))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicGeneralOrg, l["Menu:TDcmpReports:CcicGeneralOrg"], "/TDcmp/CcicGeneralOrgs/CcicGeneralOrg", icon: "fas fa-list", order: 6)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicId))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicId, l["Menu:TDcmpReports:CcicId"], "/TDcmp/CcicIds/CcicId", icon: "fas fa-list", order: 7)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicName))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicName, l["Menu:TDcmpReports:CcicName"], "/TDcmp/CcicNames/CcicName", icon: "fas fa-list", order: 9)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicPersonalRelation))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicPersonalRelation, l["Menu:TDcmpReports:CcicPersonalRelation"], "/TDcmp/CcicPersonalRelations/CcicPersonalRelation", icon: "fas fa-list", order: 10)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicPhone))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicPhone, l["Menu:TDcmpReports:CcicPhone"], "/TDcmp/CcicPhones/CcicPhone", icon: "fas fa-list", order: 11)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicPractice))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicPractice, l["Menu:TDcmpReports:CcicPractice"], "/TDcmp/CcicPractices/CcicPractice", icon: "fas fa-list", order: 12)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicRegister))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicRegister, l["Menu:TDcmpReports:CcicRegister"], "/TDcmp/CcicRegisters/CcicRegister", icon: "fas fa-list", order: 13)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicSignOrg))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicSignOrg, l["Menu:TDcmpReports:CcicSignOrg"], "/TDcmp/CcicSignOrgs/CcicSignOrg", icon: "fas fa-list", order: 14)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.TDcmpReports.CcicCustomerType))
            {
                tDcmpMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.CcicCustomerType, l["Menu:TDcmpReports:CcicCustomerType"], "/TDcmp/CcicCustomerTypes/CcicCustomerType", icon: "fas fa-list", order: 15)
                );
            }

            context.Menu.AddItem(tDcmpMenu);
        }

        //系统报表
        if (await context.IsGrantedAsync(DataPlanePermissions.Reports.Defaults))
        {
            var reportsMenu = new ApplicationMenuItem(DataPlaneMenus.Reports, l["Menu:Reports"], icon: "fas fa-newspaper", order: 4);

            if (await context.IsGrantedAsync(DataPlanePermissions.Reports.ConvertedCusOrgUnit))
            {
                reportsMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.Reports_ConvertedCusOrgUnit, l["Menu:Reports:ConvertedCusOrgUnit"], "/Reports/Pa/ConvertedCusOrgUnits/ConvertedCusOrgUnit", icon: "fas fa-newspaper")
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.Reports.ConvertedCus))
            {
                reportsMenu.AddItem(new ApplicationMenuItem(DataPlaneMenus.Reports_ConvertedCus, l["Menu:Reports:ConvertedCus"], "/Reports/Pa/ConvertedCuses/ConvertedCus", icon: "fas fa-newspaper"));
            }

            context.Menu.AddItem(reportsMenu);
        }

        //字典管理
        if (await context.IsGrantedAsync(DataPlanePermissions.Dictionaries.Default))
        {
            var dictionariesMenu = new ApplicationMenuItem(DataPlaneMenus.Dictionaries, l["Menu:Dictionaries"], icon: "fas fa-book", order: 5);

            if (await context.IsGrantedAsync(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate))
            {
                dictionariesMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.OrganizationUnitCoordinate, l["Menu:Dictionaries:OrganizationUnitCoordinates"], "/Dictionaries/OrganizationUnitCoordinate", order: 1, icon: "fas fa-building", requiredPermissionName: DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)
                );
            }

            if (await context.IsGrantedAsync(DataPlanePermissions.Dictionaries.OrgUnitHierarchy))
            {
                dictionariesMenu.AddItem(
                    new ApplicationMenuItem(DataPlaneMenus.OrgUnitHierarchy, l["Menu:Dictionaries:OrgUnitHierarchy"], "/Dictionaries/OrgUnitHierarchy", icon: "fas fa-bars")
                );
            }

            context.Menu.AddItem(dictionariesMenu);
        }

        //数据处理工作流
        if (await context.IsGrantedAsync(DataPlanePermissions.WorkFlows.Default))
        {
            var workFlowMenu = new ApplicationMenuItem(DataPlaneMenus.WorkFlows, l["Menu:WorkFlows"], icon: "fas fa-cogs", order: 6);
            if (await context.IsGrantedAsync(DataPlanePermissions.WorkFlows.CcicCusInfo))
            {
                workFlowMenu.AddItem(new ApplicationMenuItem(DataPlaneMenus.WorkFlows_CcicCusInfos, l["Menu:WorkFlows:CcicCusInfo"], url: "/WorkFlows/CcicCusInfos", icon: "fas fa-cog", order: 1));
            }
            context.Menu.AddItem(workFlowMenu);
        }



    }

    private async Task SetAdministrationMenuAsync(MenuConfigurationContext context, IStringLocalizer l)
    {
        var administration = context.Menu.GetAdministration();

        if (MultiTenancyConsts.IsEnabled)
        {
            //administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        var backgroundJobsMenu = new ApplicationMenuItem(DataPlaneMenus.BackgroundJobs, l["Menu:BackgroundJobs"], icon: "fas fa-tasks", order: 4, requiredPermissionName: DataPlanePermissions.BackgroundJobs.Default);

        backgroundJobsMenu.AddItem(new ApplicationMenuItem(DataPlaneMenus.BackgroundJobs_Index, l["Menu:BackgroundJobs:Index"], icon: "fas fa-tasks", order: 1, url: "/BackgroundJobs/Index", requiredPermissionName: DataPlanePermissions.BackgroundJobs.Default));

        administration.AddItem(backgroundJobsMenu);

        if (await context.IsGrantedAsync(DataPlanePermissions.OrganizationUnits.Default))
        {
            var identity = administration.GetMenuItem(IdentityMenuNames.GroupName);

            identity.AddItem(new ApplicationMenuItem(DataPlaneMenus.OrganizationUnit, l["Menu:OrganizationUnit"], "/Identity/OrganizationUnits"));
        }
        administration.Order = 10000;
    }
}
