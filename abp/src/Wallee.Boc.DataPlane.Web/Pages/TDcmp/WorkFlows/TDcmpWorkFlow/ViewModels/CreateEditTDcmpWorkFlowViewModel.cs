using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;

public class CreateEditTDcmpWorkFlowViewModel
{
    [Display(Name = "TDcmpWorkFlowStatus")]
    public TDcmpStatus Status { get; set; }

    [Display(Name = "TDcmpWorkFlowDataDate")]
    public DateTime DataDate { get; set; }

    [Display(Name = "TDcmpWorkFlowComment")]
    public string? Comment { get; set; }
}
