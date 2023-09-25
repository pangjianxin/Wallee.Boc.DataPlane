using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.CcicCusInfoWorkFlow
{
    [Widget(
       StyleTypes = new[] { typeof(CcicInfoWorkFlowStyleBundleContributor) },
       ScriptTypes = new[] { typeof(CcicInfoWorkFlowScriptBundleContributor) })]
    [ViewComponent(Name = "CcicCusInfoWorkFlow")]
    public class CcicCusInfoWorkFlowViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class CcicInfoWorkFlowStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/CcicCusInfoWorkFlow/Default.css");
        }
    }

    public class CcicInfoWorkFlowScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/CcicCusInfoWorkFlow/Default.js");
        }
    }
}
