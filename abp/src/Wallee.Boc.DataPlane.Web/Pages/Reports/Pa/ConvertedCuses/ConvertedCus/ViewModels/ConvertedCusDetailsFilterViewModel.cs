using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels
{
    public class ConvertedCusDetailsFilterViewModel
    {
        [Required]
        [Display(Name = "数据日期")]
        [DataType(DataType.Date)]
        public DateTime? DataDate { get; set; }
    }
}
