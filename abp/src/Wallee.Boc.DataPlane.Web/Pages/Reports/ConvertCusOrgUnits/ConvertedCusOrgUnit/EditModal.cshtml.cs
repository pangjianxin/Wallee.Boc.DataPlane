using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit;

public class EditModalModel : DataPlanePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditConvertedCusOrgUnitViewModel ViewModel { get; set; }

    private readonly IConvertedCusOrgUnitAppService _service;

    public EditModalModel(IConvertedCusOrgUnitAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ConvertedCusOrgUnitDto, CreateEditConvertedCusOrgUnitViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditConvertedCusOrgUnitViewModel, CreateUpdateConvertedCusOrgUnitDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}