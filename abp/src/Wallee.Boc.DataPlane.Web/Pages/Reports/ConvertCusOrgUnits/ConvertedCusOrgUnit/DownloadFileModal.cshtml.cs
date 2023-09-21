using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit
{
    public class DownloadFileModalModel : DataPlanePageModel
    {
        [BindProperty]
        public DateTime DataDate { get; set; }

        private readonly IConvertedCusOrgUnitAppService _convertedCusOrgUnitAppService;

        public DownloadFileModalModel(
            IConvertedCusOrgUnitAppService convertedCusOrgUnitAppService)
        {
            _convertedCusOrgUnitAppService = convertedCusOrgUnitAppService;
        }
        public void OnGet()
        {
            DataDate = Clock.Now.AddDays(-1);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _convertedCusOrgUnitAppService.DataExistedAsync(DataDate))
            {
                throw new UserFriendlyException($"{DataDate:yyyyMMdd}不存在数据");
            }
            return Content($"{DataDate.Date:yyyy-MM-dd}");
        }
    }
}