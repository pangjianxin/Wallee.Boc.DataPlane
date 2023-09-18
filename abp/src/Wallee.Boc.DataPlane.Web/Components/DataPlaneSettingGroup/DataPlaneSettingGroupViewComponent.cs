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
                ConvertedCusOrgUnitFirstLevel = settings.ConvertedCusOrgUnitFirstLevel,
                ConvertedCusOrgUnitSecondLevel = settings.ConvertedCusOrgUnitSecondLevel,
                ConvertedCusOrgUnitThirdLevel = settings.ConvertedCusOrgUnitThirdLevel,
                ConvertedCusOrgUnitFourthLevel = settings.ConvertedCusOrgUnitFourthLevel,
                ConvertedCusOrgUnitFifthLevel = settings.ConvertedCusOrgUnitFifthLevel,
                ConvertedCusOrgUnitSixthLevel = settings.ConvertedCusOrgUnitSixthLevel,
            });
        }

        public class UpdateDataPlaneSettingsViewModel
        {
            [Required]
            [Display(Name = "TDcmp工作流Cron")]
            public string TDcmpWorkFlowCronExpression { get; set; } = default!;
            [Required]
            [Display(Name = "2000-20万日均折算率")]
            public decimal ConvertedCusOrgUnitFirstLevel { get; set; }
            [Required]
            [Display(Name = "20万-50万日均折算率")]
            public decimal ConvertedCusOrgUnitSecondLevel { get; set; }
            [Required]
            [Display(Name = "50万-500万日均折算率")]
            public decimal ConvertedCusOrgUnitThirdLevel { get; set; }
            [Required]
            [Display(Name = "500万-2000万日均折算率")]
            public decimal ConvertedCusOrgUnitFourthLevel { get; set; }
            [Required]
            [Display(Name = "2000万-1亿元日均折算率")]
            public decimal ConvertedCusOrgUnitFifthLevel { get; set; }
            [Required]
            [Display(Name = "1亿元日均以上折算率")]
            public decimal ConvertedCusOrgUnitSixthLevel { get; set; }
        }
    }
}
