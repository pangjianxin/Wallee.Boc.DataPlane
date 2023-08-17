using Volo.Abp.Settings;

namespace Wallee.Boc.DataPlane.Settings;

public class DataPlaneSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DataPlaneSettings.MySetting1));
    }
}
