using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels
{
    public class ConvertedCusFilterViewModel
    {
        [Display(Name = "模糊查找(输入客户号)")]
        public string? Filter { get; set; }

        [Required]
        [Display(Name = "数据日期")]
        [DataType(DataType.Date)]
        public DateTime? DataDate { get; set; }

       
    }
}
