using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow;

public class EditModalModel : DataPlanePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditTDcmpWorkFlowViewModel ViewModel { get; set; } = default!;

    private readonly ITDcmpWorkFlowAppService _service;

    public EditModalModel(ITDcmpWorkFlowAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<TDcmpWorkFlowDto, CreateEditTDcmpWorkFlowViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditTDcmpWorkFlowViewModel, CreateUpdateTDcmpWorkFlowDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}