using AutoMapper;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrganizationUnitCoordinate.ViewModels;
using Wallee.Boc.DataPlane.Web.Pages.Identity.OrganizationUnits;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.CusOrgAdjusment.ViewModels;
using Wallee.Boc.DataPlane.Web.Pages.WorkFlows.CcicCusInfos.ViewModels;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.Web;

public class DataPlaneWebAutoMapperProfile : Profile
{
    public DataPlaneWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<OrganizationUnitCreateViewModel, OrganizationUnitCreateDto>().MapExtraProperties();
        CreateMap<OrganizationUnitUpdateViewModel, OrganizationUnitUpdateDto>().MapExtraProperties();
        CreateMap<OrganizationUnitDto, OrganizationUnitUpdateViewModel>().MapExtraProperties();
        CreateMap<CcicCusInfoWorkFlowDto, CreateEditCcicCusInfoWorkFlowViewModel>();
        CreateMap<CreateEditCcicCusInfoWorkFlowViewModel, CreateUpdateCcicCusInfoWorkFlowDto>();
        CreateMap<OrganizationUnitCoordinateDto, CreateEditOrganizationUnitCoordinateViewModel>();
        CreateMap<CreateEditOrganizationUnitCoordinateViewModel, CreateUpdateOrganizationUnitCoordinateDto>();
        CreateMap<ConvertedCusDto, CreateEditConvertedCusByFileViewModel>();
        CreateMap<CusOrgAdjusmentDto, CreateEditCusOrgAdjusmentByFileViewModel>();
        CreateMap<CreateEditCusOrgAdjusmentByFileViewModel, CreateUpdateCusOrgAdjusmentByFileDto>();
    }
}
