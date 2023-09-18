using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusFstRange
{
    [Widget(
        ScriptFiles = new[] { "/Pages/Components/ConvertedCusFstRange/Default.js" },
        StyleFiles = new[] { "/Pages/Components/ConvertedCusFstRange/Default.css" }
        )]
    [ViewComponent(Name = "ConvertedCusFstRange")]
    public class ConvertedCusFstRangeViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
