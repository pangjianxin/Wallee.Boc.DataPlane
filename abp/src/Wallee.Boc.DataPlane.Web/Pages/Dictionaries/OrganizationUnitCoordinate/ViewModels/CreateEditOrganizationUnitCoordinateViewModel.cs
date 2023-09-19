using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;

public class CreateEditOrganizationUnitCoordinateViewModel
{
    [Required]
    [Display(Name = "��������")]
    public string OrgName { get; set; } = default!;

    [Required]
    [Display(Name = "������")]
    public string OrgNo { get; set; } = default!;

    [Required]
    [Display(Name = "����")]
    public double Longitude { get; set; }

    [Required]
    [Display(Name = "γ��")]
    public double Latitude { get; set; }

    [Required]
    [Display(Name = "��������")]
    public string RegionCode { get; set; } = default!;

}
