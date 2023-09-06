using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.TDcmpWorkFlow
{
    [Widget(
       StyleTypes = new[] { typeof(TDcmpWorkFlowStyleBundleContributor) },
       ScriptTypes = new[] { typeof(TDcmpWorkFlowScriptBundleContributor) })]
    public class TDcmpWorkFlowViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class TDcmpWorkFlowStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/TDcmpWorkFlow/Default.css");
        }
    }

    public class TDcmpWorkFlowScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/TDcmpWorkFlow/Default.js");
        }
    }
}
