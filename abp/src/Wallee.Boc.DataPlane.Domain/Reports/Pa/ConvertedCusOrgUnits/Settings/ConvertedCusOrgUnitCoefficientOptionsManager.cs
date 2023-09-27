using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.Options;
using Volo.Abp.Settings;
using Wallee.Boc.DataPlane.Settings;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Settings
{
    public class ConvertedCusOrgUnitCoefficientOptionsManager : AbpDynamicOptionsManager<ConvertedCusOrgUnitCoefficientOptions>
    {
        public ISettingProvider SettingProvider { get; }
        public ConvertedCusOrgUnitCoefficientOptionsManager(
            ISettingProvider settingProvider,
            IOptionsFactory<ConvertedCusOrgUnitCoefficientOptions> factory)
            : base(factory)
        {
            SettingProvider = settingProvider;
        }

        protected override async Task OverrideOptionsAsync(string name, ConvertedCusOrgUnitCoefficientOptions options)
        {

            var firstLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitFirstLevel);
            var secondLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitSecondLevel);
            var thirdLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitThirdLevel);
            var fourthLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitFourthLevel);
            var fifthLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitFifthLevel);
            var sixthLevel = await SettingProvider.GetAsync<decimal>(DataPlaneSettings.ConvertedCusOrgUnitSixthLevel);

            options.FirstLevel = firstLevel == default ? options.FirstLevel : firstLevel;
            options.SecondLevel = secondLevel == default ? options.SecondLevel : secondLevel;
            options.ThirdLevel = thirdLevel == default ? options.ThirdLevel : thirdLevel;
            options.FourthLevel = fourthLevel == default ? options.FourthLevel : fourthLevel;
            options.FifthLevel = fifthLevel == default ? options.FifthLevel : fifthLevel;
            options.SixthLevel = sixthLevel == default ? options.SixthLevel : sixthLevel;
        }
    }
}
