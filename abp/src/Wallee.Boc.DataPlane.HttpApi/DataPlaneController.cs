using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wallee.Boc.DataPlane;

/* Inherit your controllers from this class.
 */
public abstract class DataPlaneController : AbpControllerBase
{
    protected DataPlaneController()
    {
        LocalizationResource = typeof(DataPlaneResource);
    }
}
