using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy;

public class EditModalModel : DataPlanePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditOrgUnitHierarchyViewModel ViewModel { get; set; } = default!;

    private readonly IOrgUnitHierarchyAppService _service;

    public EditModalModel(IOrgUnitHierarchyAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<OrgUnitHierarchyDto, EditOrgUnitHierarchyViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditOrgUnitHierarchyViewModel, UpdateOrgUnitHierarchyDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}