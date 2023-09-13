using AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.BackgroundJobs;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Wallee.Boc.DataPlane.TDcmp.CcicIds.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Wallee.Boc.DataPlane.TDcmp.CcicNames.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Wallee.Boc.DataPlane.Dictionaries;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

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
        CreateMap<CcicAntiMoneyLaundering, CcicAntiMoneyLaunderingDto>();
        CreateMap<CcicCustomerTypeOrg, CcicCustomerTypeOrgDto>();
        CreateMap<CcicGeneralOrg, CcicGeneralOrgDto>();
        CreateMap<CcicId, CcicIdDto>();
        CreateMap<CcicName, CcicNameDto>();
        CreateMap<CcicPersonalRelation, CcicPersonalRelationDto>();
        CreateMap<CcicPhone, CcicPhoneDto>();
        CreateMap<CcicPractice, CcicPracticeDto>();
        CreateMap<CcicRegister, CcicRegisterDto>();
        CreateMap<CcicSignOrg, CcicSignOrgDto>();
        CreateMap<CcicCustomerType, CcicCustomerTypeDto>();
        CreateMap<OrganizationUnitCoordinate, OrganizationUnitCoordinateDto>();
        CreateMap<CreateUpdateOrganizationUnitCoordinateDto, OrganizationUnitCoordinate>(MemberList.Source);
    }
}
