using System;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.Dictionaries;


public interface IOrganizationUnitCoordinateAppService :
    ICrudAppService< 
        OrganizationUnitCoordinateDto, 
        Guid, 
        OrganizationUnitCoordinateGetListInput,
        CreateUpdateOrganizationUnitCoordinateDto,
        CreateUpdateOrganizationUnitCoordinateDto>
{

}