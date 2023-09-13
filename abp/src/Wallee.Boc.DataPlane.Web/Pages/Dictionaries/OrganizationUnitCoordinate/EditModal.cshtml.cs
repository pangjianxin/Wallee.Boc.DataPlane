using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate;

public class EditModalModel : DataPlanePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditOrganizationUnitCoordinateViewModel ViewModel { get; set; } = default!;

    private readonly IOrganizationUnitCoordinateAppService _service;

    public EditModalModel(IOrganizationUnitCoordinateAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<OrganizationUnitCoordinateDto, CreateEditOrganizationUnitCoordinateViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditOrganizationUnitCoordinateViewModel, CreateUpdateOrganizationUnitCoordinateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}