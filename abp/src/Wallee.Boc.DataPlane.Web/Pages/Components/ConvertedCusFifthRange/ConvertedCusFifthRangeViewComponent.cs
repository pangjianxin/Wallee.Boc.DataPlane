using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusFifthRange
{
    [Widget(
     ScriptFiles = new[] { "/Pages/Components/ConvertedCusFifthRange/Default.js" },
     StyleFiles = new[] { "/Pages/Components/ConvertedCusFifthRange/Default.css" }
     )]
    [ViewComponent(Name = "ConvertedCusFifthRange")]
    public class ConvertedCusFifthRangeViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
