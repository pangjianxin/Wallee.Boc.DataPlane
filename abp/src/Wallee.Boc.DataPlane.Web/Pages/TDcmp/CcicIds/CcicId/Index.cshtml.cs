using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.CcicIds.CcicId;

public class IndexModel : DataPlanePageModel
{
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
