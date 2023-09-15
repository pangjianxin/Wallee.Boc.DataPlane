using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.ConvertCusOrgUnits.ConvertedCusOrgUnit;

public class CreateModalModel : DataPlanePageModel
{
    [BindProperty]
    public CreateEditConvertedCusOrgUnitViewModel ViewModel { get; set; }

    private readonly IConvertedCusOrgUnitAppService _service;

    public CreateModalModel(IConvertedCusOrgUnitAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditConvertedCusOrgUnitViewModel, CreateUpdateConvertedCusOrgUnitDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}