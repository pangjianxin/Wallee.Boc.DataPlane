using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;

public class CreateEditOrganizationUnitCoordinateViewModel
{
    [Display(Name = "��������")]
    public string OrgName { get; set; } = default!;

    [Display(Name = "������")]
    public string OrgNo { get; set; } = default!;

    [Display(Name = "γ��")]
    public double Latitude { get; set; }

    [Display(Name = "����")]
    public double Longitude { get; set; }
}
