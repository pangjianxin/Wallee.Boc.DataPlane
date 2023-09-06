using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;

public class CreateEditTDcmpWorkFlowViewModel
{
    [Required]
    [Display(Name = "TDcmpWorkFlowDataDate")]
    public DateTime DataDate { get; set; }

    [Required]
    [Display(Name = "Cron±Ì¥Ô Ω")]
    public string CronExpression { get; set; } = default!;
}
