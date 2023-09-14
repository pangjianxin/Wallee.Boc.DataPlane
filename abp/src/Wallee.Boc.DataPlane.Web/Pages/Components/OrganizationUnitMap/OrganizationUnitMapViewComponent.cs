using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Wallee.Boc.DataPlane.Web.Pages.Components.OrganizationUnitMap
{
    [Widget(
   StyleTypes = new[] { typeof(OrganizationUnitMapStyleBundleContributor) },
   ScriptTypes = new[] { typeof(OrganizationUnitMapScriptBundleContributor) }
   )]
    [ViewComponent(Name = "OrganizationUnitMap")]
    public class OrganizationUnitMapViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class OrganizationUnitMapStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/OrganizationUnitMap/Default.css");
        }
    }
    public class OrganizationUnitMapScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/OrganizationUnitMap/Default.js");
        }
    }
}
