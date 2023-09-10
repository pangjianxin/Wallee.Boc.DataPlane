using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.CcicPractices.CcicPractice;

public class IndexModel : DataPlanePageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

