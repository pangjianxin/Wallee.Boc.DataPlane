using AutoMapper;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Identity.OrganizationUnits;
using Wallee.Boc.DataPlane.Web.Pages.TDcmp.WorkFlows.TDcmpWorkFlow.ViewModels;

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
