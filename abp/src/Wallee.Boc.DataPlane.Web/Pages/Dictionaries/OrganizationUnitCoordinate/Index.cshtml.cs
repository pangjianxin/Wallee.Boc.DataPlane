using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate;

public class IndexModel : DataPlanePageModel
{
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

