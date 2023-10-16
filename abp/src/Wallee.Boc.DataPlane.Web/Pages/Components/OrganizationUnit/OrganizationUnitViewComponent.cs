using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.OrganizationUnit
{
    [Widget(
         ScriptFiles = new[] { "/Pages/Components/OrganizationUnit/Default.js" },
         StyleFiles = new[] { "/Pages/Components/OrganizationUnit/Default.css" }
        )]
    [ViewComponent(Name = "OrganizationUnit")]
    public class OrganizationUnitViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
