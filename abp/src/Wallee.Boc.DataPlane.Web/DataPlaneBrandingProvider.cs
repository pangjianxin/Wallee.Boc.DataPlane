using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.Web;

[Dependency(ReplaceServices = true)]
public class DataPlaneBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DataPlane";
}
