using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

public class CreateEditConvertedCusByFileViewModel
{
    [Required]
    [DynamicFormIgnore]
    public IRemoteStreamContent File { get; set; } = default!;
}
