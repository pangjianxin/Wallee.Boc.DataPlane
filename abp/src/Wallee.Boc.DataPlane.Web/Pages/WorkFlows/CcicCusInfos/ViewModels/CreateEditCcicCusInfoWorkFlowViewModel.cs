using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CcicCusInfos.ViewModels;

public class CreateEditCcicCusInfoWorkFlowViewModel
{
    [Required]
    [Display(Name = "TDcmpWorkFlowDataDate")]
    public DateTime DataDate { get; set; }
}
