using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit.ViewModels;

public class CreateEditConvertedCusOrgUnitViewModel
{
    [Display(Name = "ConvertedCusOrgUnitLabel")]
    public string Label { get; set; } = default!;

    [Display(Name = "ConvertedCusOrgUnitUpOrgidt")]
    public string UpOrgidt { get; set; } = default!;

    [Display(Name = "ConvertedCusOrgUnitOrgidt")]
    public string Orgidt { get; set; } = default!;

    [Display(Name = "ConvertedCusOrgUnitFirstLevel")]
    public decimal FirstLevel { get; set; }

    [Display(Name = "ConvertedCusOrgUnitSecondLevel")]
    public decimal SecondLevel { get; set; }

    [Display(Name = "ConvertedCusOrgUnitThirdLevel")]
    public decimal ThirdLevel { get; set; }

    [Display(Name = "ConvertedCusOrgUnitFourthLevel")]
    public decimal FourthLevel { get; set; }

    [Display(Name = "ConvertedCusOrgUnitFifthLevel")]
    public decimal FifthLevel { get; set; }

    [Display(Name = "ConvertedCusOrgUnitSixthLevel")]
    public decimal SixthLevel { get; set; }
    [Display(Name = "数据日期")]
    public DateTime DataDate { get; set; }
}
