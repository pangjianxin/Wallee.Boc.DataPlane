using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy;

public class CreateModalModel : DataPlanePageModel
{
    [BindProperty]
    public CreateOrgUnitHierarchyViewModel ViewModel { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public Guid? ParentId { get; set; }

    private readonly IOrgUnitHierarchyAppService _service;

    public CreateModalModel(IOrgUnitHierarchyAppService service)
    {
        _service = service;
    }
    public void OnGet()
    {
        ViewModel = new CreateOrgUnitHierarchyViewModel { ParentId = ParentId };
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateOrgUnitHierarchyViewModel, CreateOrgUnitHierarchyDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}