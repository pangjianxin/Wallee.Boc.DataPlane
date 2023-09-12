using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    public class DataPlaneSettingsAppService : SettingManagementAppServiceBase, IDataPlaneSettingsAppService
    {
        private readonly ISettingManager _settingManager;

        public DataPlaneSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }
        public async Task UpdateDataPlaneSettingsAsync(UpdateDataPlaneSettingsDto input)
        {
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.TDcmpWorkFlowCronExpression, input.TDcmpWorkFlowCronExpression);
        }

        public async Task<DataPlaneSettingsDto> GetDataPlaneSettingsAsync()
        {
            return new DataPlaneSettingsDto
            {
                TDcmpWorkFlowCronExpression = await SettingProvider.GetOrNullAsync(Settings.DataPlaneSettings.TDcmpWorkFlowCronExpression),
            };
        }
    }
}
