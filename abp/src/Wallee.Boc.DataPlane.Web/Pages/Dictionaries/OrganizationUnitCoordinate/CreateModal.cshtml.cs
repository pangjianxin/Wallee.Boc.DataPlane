using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate;

public class CreateModalModel : DataPlanePageModel
{
    [BindProperty]
    public CreateEditOrganizationUnitCoordinateViewModel ViewModel { get; set; } = default!;

    private readonly IOrganizationUnitCoordinateAppService _service;

    public CreateModalModel(IOrganizationUnitCoordinateAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditOrganizationUnitCoordinateViewModel, CreateUpdateOrganizationUnitCoordinateDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}