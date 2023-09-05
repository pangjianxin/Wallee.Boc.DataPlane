using AutoMapper;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;
using Wallee.Boc.DataPlane.Web.Pages.Identity.OrganizationUnits;

namespace Wallee.Boc.DataPlane.Web;

public class DataPlaneWebAutoMapperProfile : Profile
{
    public DataPlaneWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<OrganizationUnitCreateViewModel, OrganizationUnitCreateDto>().MapExtraProperties();
        CreateMap<OrganizationUnitUpdateViewModel, OrganizationUnitUpdateDto>().MapExtraProperties();
        CreateMap<OrganizationUnitDto, OrganizationUnitUpdateViewModel>().MapExtraProperties();
        CreateMap<TDcmpWorkFlowDto, CreateEditTDcmpWorkFlowViewModel>();
        CreateMap<CreateEditTDcmpWorkFlowViewModel, CreateUpdateTDcmpWorkFlowDto>();
    }
}
