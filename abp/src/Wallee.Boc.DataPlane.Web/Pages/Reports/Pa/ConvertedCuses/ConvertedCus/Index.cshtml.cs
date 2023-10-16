using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus;

public class IndexModel : DataPlanePageModel
{
    public ConvertedCusDetailsFilterViewModel ConvertedCusDetailsFilter { get; set; } = default!;
    public virtual void OnGet()
    {
        ConvertedCusDetailsFilter = new ConvertedCusDetailsFilterViewModel
        {
            DataDate = Clock.Now.AddDays(-1)
        };
    }
}
