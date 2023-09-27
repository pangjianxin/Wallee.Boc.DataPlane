using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertCusOrgUnits.ConvertedCusOrgUnit.ViewModels
{
    public class CreateConvertedCusOrgUnitByFileViewModel
    {
        [Required]
        [DynamicFormIgnore]
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
