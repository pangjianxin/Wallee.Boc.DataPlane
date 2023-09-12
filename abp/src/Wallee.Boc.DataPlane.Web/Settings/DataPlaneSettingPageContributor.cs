using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Web.Components.DataPlaneSettingGroup;

namespace Wallee.Boc.DataPlane.Web.Settings
{
    public class DataPlaneSettingPageContributor : SettingPageContributorBase
    {
        public DataPlaneSettingPageContributor()
        {
           // RequiredPermissions(DataPlanePermissions.Settings.Default);
        }
        public override Task ConfigureAsync(SettingPageCreationContext context)
        {
            context.Groups.Add(
                new SettingPageGroup(
                    "Wallee.Boc.DataPlane.DataPlaneSettingGroup",
                    "系统设置",
                    typeof(DataPlaneSettingGroupViewComponent)
                )
            );

            return Task.CompletedTask;
        }

        public override async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var auth = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            var permit = await auth.IsGrantedAnyAsync(DataPlanePermissions.Settings.Default);
            return permit;
        }
    }
}
