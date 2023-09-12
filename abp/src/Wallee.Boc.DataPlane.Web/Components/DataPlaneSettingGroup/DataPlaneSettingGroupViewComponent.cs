using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.DataPlaneSettings;

namespace Wallee.Boc.DataPlane.Web.Components.DataPlaneSettingGroup
{
    public class DataPlaneSettingGroupViewComponent : AbpViewComponent
    {
        private readonly IDataPlaneSettingsAppService _dataPlaneSettingsAppService;

        public DataPlaneSettingGroupViewComponent(IDataPlaneSettingsAppService dataPlaneSettingsAppService)
        {
            _dataPlaneSettingsAppService = dataPlaneSettingsAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _dataPlaneSettingsAppService.GetDataPlaneSettingsAsync();

            return View("~/Components/DataPlaneSettingGroup/Default.cshtml", new UpdateDataPlaneSettingsViewModel
            {
                TDcmpWorkFlowCronExpression = settings.TDcmpWorkFlowCronExpression,
            });
        }

        public class UpdateDataPlaneSettingsViewModel
        {
            [Required]
            [Display(Name = "TDcmp工作流Cron")]
            public string TDcmpWorkFlowCronExpression { get; set; } = default!;
        }
    }
}
