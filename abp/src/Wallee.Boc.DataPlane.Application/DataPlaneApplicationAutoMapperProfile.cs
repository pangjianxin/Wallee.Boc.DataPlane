using AutoMapper;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane;

public class DataPlaneApplicationAutoMapperProfile : Profile
{
    public DataPlaneApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<OrganizationUnit, OrganizationUnitDto>().MapExtraProperties();
        CreateMap<CcicBasic, CcicBasicDto>();
        CreateMap<CcicAddress, CcicAddressDto>();
        CreateMap<TDcmpWorkFlow, TDcmpWorkFlowDto>().ForMember(it => it.TotalTaskCount, config => config.MapFrom(it => it.TotalTaskCount));
        CreateMap<CreateUpdateTDcmpWorkFlowDto, TDcmpWorkFlow>(MemberList.Source);
        CreateMap<BackgroundJobRecord, BackgroundJobRecordDto>();
    }
}
