using Volo.Abp.Settings;

namespace Wallee.Boc.DataPlane.Settings;

public class DataPlaneSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DataPlaneSettings.MySetting1));

        context.Add(new SettingDefinition(DataPlaneSettings.TDcmpWorkFlowCronExpression));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitFirstLevel));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitSecondLevel));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitThirdLevel));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitFourthLevel));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitFifthLevel));
        context.Add(new SettingDefinition(DataPlaneSettings.ConvertedCusOrgUnitSixthLevel));
    }
}
