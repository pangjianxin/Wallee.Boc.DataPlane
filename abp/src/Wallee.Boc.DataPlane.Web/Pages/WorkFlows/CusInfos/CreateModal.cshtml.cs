using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CusInfos.ViewModels;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CusInfos;

public class CreateModalModel : DataPlanePageModel
{
    [BindProperty]
    public CreateEditCcicCusInfoWorkFlowViewModel ViewModel { get; set; } = default!;

    private readonly ICcicCusInfoWorkFlowAppService _service;

    public CreateModalModel(ICcicCusInfoWorkFlowAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCcicCusInfoWorkFlowViewModel, CreateUpdateCcicCusInfoWorkFlowDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}