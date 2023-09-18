using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusFourthRange
{
    [Widget(
        ScriptFiles = new[] { "/Pages/Components/ConvertedCusFourthRange/Default.js" },
        StyleFiles = new[] { "/Pages/Components/ConvertedCusFourthRange/Default.css" }
        )]
    [ViewComponent(Name = "ConvertedCusFourthRange")]
    public class ConvertedCusFourthRangeViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
