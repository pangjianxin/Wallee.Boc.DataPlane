using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow;

public class CreateModalModel : DataPlanePageModel
{
    [BindProperty]
    public CreateEditTDcmpWorkFlowViewModel ViewModel { get; set; }

    private readonly ITDcmpWorkFlowAppService _service;

    public CreateModalModel(ITDcmpWorkFlowAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTDcmpWorkFlowViewModel, CreateUpdateTDcmpWorkFlowDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}