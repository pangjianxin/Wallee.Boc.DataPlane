using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCusOrgUnits.ConvertedCusOrgUnit;

public class IndexModel : DataPlanePageModel
{
    public ConvertedCusFilterViewModel ConvertedCusFilter { get; set; } = default!;
    public virtual async Task OnGetAsync()
    {
        ConvertedCusFilter = new ConvertedCusFilterViewModel
        {
            DataDate = Clock.Now.AddDays(-1)
        };
        await Task.CompletedTask;
    }
}
