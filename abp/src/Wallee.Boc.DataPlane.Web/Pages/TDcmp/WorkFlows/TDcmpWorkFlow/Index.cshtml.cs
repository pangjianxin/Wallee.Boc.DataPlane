using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow;

public class IndexModel : DataPlanePageModel
{
    public TDcmpWorkFlowFilterInput TDcmpWorkFlowFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class TDcmpWorkFlowFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TDcmpWorkFlowStatus")]
    public TDcmpStatus? Status { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TDcmpWorkFlowDataDate")]
    public DateTime? DataDate { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "TDcmpWorkFlowComment")]
    public string? Comment { get; set; }
}
