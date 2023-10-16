using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Timing;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels
{
    public class ConvertedCusDetailsFilterViewModel : IValidatableObject
    {
        [Required]
        [Display(Name = "数据日期")]
        [DataType(DataType.Date)]
        public DateTime? DataDate { get; set; }

        [Required]
        [Display(Name = "机构")]
        public string? Orgidt { get; set; } = default!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var clock = validationContext.GetRequiredService<IClock>();

            if (DataDate > clock.Now.AddDays(-1))
            {
                yield return new ValidationResult("数据日期不能大于T+1");
            }
        }
    }
}
