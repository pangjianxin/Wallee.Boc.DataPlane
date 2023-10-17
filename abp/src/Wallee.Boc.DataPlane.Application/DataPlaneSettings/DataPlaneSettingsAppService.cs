using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

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
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitFirstLevel, $"{input.ConvertedCusOrgUnitFirstLevel}");
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitSecondLevel, $"{input.ConvertedCusOrgUnitSecondLevel}");
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitThirdLevel, $"{input.ConvertedCusOrgUnitThirdLevel}");
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitFourthLevel, $"{input.ConvertedCusOrgUnitFourthLevel}");
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitFifthLevel, $"{input.ConvertedCusOrgUnitFifthLevel}");
            await _settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, Settings.DataPlaneSettings.ConvertedCusOrgUnitSixthLevel, $"{input.ConvertedCusOrgUnitSixthLevel}");

        }

        public async Task<DataPlaneSettingsDto> GetDataPlaneSettingsAsync()
        {
            return new DataPlaneSettingsDto
            {
                TDcmpWorkFlowCronExpression = (await SettingProvider.GetOrNullAsync(Settings.DataPlaneSettings.TDcmpWorkFlowCronExpression))!,
                ConvertedCusOrgUnitFirstLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitFirstLevel),
                ConvertedCusOrgUnitSecondLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitSecondLevel),
                ConvertedCusOrgUnitThirdLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitThirdLevel),
                ConvertedCusOrgUnitFourthLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitFourthLevel),
                ConvertedCusOrgUnitFifthLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitFifthLevel),
                ConvertedCusOrgUnitSixthLevel = await SettingProvider.GetAsync<decimal>(Settings.DataPlaneSettings.ConvertedCusOrgUnitSixthLevel),
            };
        }
    }
}
