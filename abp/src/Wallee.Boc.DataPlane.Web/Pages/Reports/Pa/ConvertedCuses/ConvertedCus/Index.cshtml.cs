using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus;

public class IndexModel : DataPlanePageModel
{
    public ConvertedCusDetailsFilterViewModel ViewModel { get; set; } = default!;
    public virtual void OnGet()
    {
        ViewModel = new ConvertedCusDetailsFilterViewModel
        {

        };
    }
}
