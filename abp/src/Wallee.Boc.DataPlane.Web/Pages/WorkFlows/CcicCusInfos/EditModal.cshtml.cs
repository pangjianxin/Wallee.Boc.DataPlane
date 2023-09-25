using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CcicCusInfos.ViewModels;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CcicCusInfos;

public class EditModalModel : DataPlanePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditCcicCusInfoWorkFlowViewModel ViewModel { get; set; } = default!;

    private readonly ICcicCusInfoWorkFlowAppService _service;

    public EditModalModel(ICcicCusInfoWorkFlowAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CcicCusInfoWorkFlowDto, CreateEditCcicCusInfoWorkFlowViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCcicCusInfoWorkFlowViewModel, CreateUpdateCcicCusInfoWorkFlowDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}