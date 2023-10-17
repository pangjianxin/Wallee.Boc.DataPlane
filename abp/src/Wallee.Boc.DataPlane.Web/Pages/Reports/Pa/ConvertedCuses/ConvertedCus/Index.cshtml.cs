using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus;

public class IndexModel : DataPlanePageModel
{
    public ConvertedCusFilterViewModel ConvertedCusFilter { get; set; } = default!;
    public virtual void OnGet()
    {
        ConvertedCusFilter = new ConvertedCusFilterViewModel
        {
            DataDate = Clock.Now.AddDays(-1)
        };
    }
}
