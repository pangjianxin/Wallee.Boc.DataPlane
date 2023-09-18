using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusThdRange
{
    [Widget(
      ScriptFiles = new[] { "/Pages/Components/ConvertedCusThdRange/Default.js" },
      StyleFiles = new[] { "/Pages/Components/ConvertedCusThdRange/Default.css" }
      )]
    [ViewComponent(Name = "ConvertedCusThdRange")]
    public class ConvertedCusThdRangeViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
