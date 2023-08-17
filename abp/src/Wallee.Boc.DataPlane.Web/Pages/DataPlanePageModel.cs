using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Wallee.Boc.DataPlane.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class DataPlanePageModel : AbpPageModel
{
    protected DataPlanePageModel()
    {
        LocalizationResourceType = typeof(DataPlaneResource);
    }
}
