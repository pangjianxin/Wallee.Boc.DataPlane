using AutoMapper;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane;

public class DataPlaneApplicationAutoMapperProfile : Profile
{
    public DataPlaneApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<OrganizationUnit, OrganizationUnitDto>().MapExtraProperties();
    }
}
