using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusSndRange
{
    [Widget(
    ScriptFiles = new[] { "/Pages/Components/ConvertedCusSndRange/Default.js" },
    StyleFiles = new[] { "/Pages/Components/ConvertedCusSndRange/Default.css" }
    )]
    [ViewComponent(Name = "ConvertedCusSndRange")]
    public class ConvertedCusSndRangeViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
