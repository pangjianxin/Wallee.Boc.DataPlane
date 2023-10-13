using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy;

public class IndexModel : DataPlanePageModel
{
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}
