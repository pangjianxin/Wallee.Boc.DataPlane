using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CusInfos.ViewModels;

public class CreateEditCcicCusInfoWorkFlowViewModel
{
    [Required]
    [Display(Name = "TDcmpWorkFlowDataDate")]
    public DateTime DataDate { get; set; }
}
