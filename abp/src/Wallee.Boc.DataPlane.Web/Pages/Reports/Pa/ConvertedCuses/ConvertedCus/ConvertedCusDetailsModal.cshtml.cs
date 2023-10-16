using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus
{
    public class ConvertedCusDetailsModalModel : DataPlanePageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Orgidt { get; set; } = default!;

        [BindProperty]
        public ConvertedCusDetailsFilterViewModel ViewModel { get; set; } = default!;

        public void OnGet()
        {
            ViewModel = new ConvertedCusDetailsFilterViewModel
            {
                DataDate = Clock.Now.AddDays(-1),
                Orgidt = Orgidt
            };
        }
    }
}
