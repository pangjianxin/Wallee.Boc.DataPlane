using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.ConvertedCusDetail
{
    [Widget(
    ScriptFiles = new[] { "/Pages/Components/ConvertedCusDetail/Default.js" },
    StyleFiles = new[] { "/Pages/Components/ConvertedCusDetail/Default.css" }
    )]
    [ViewComponent(Name = "ConvertedCusDetail")]
    public class ConvertedCusDetailViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
