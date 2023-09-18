using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusSixthRange
{
    [Widget(
     ScriptFiles = new[] { "/Pages/Components/ConvertedCusSixthRange/Default.js" },
     StyleFiles = new[] { "/Pages/Components/ConvertedCusSixthRange/Default.css" }
     )]
    [ViewComponent(Name = "ConvertedCusSixthRange")]
    public class ConvertedCusSixthRangeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
