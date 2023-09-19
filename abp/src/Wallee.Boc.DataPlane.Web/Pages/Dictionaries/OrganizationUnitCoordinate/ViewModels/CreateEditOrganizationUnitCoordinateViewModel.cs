using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;

public class CreateEditOrganizationUnitCoordinateViewModel
{
    [Required]
    [Display(Name = "机构名称")]
    public string OrgName { get; set; } = default!;

    [Required]
    [Display(Name = "机构号")]
    public string OrgNo { get; set; } = default!;

    [Required]
    [Display(Name = "经度")]
    public double Longitude { get; set; }

    [Required]
    [Display(Name = "纬度")]
    public double Latitude { get; set; }

    [Required]
    [Display(Name = "区划编码")]
    public string RegionCode { get; set; } = default!;

}
