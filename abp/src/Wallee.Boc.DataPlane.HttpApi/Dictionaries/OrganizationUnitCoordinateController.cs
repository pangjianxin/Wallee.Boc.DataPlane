using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.Dictionaries;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/dictionaries/organization-unit-coordinate")]
[Authorize]
public class OrganizationUnitCoordinateController : DataPlaneController, IOrganizationUnitCoordinateAppService
{
    private readonly IOrganizationUnitCoordinateAppService _service;

    public OrganizationUnitCoordinateController(IOrganizationUnitCoordinateAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
    [Authorize(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)]
    public virtual Task<OrganizationUnitCoordinateDto> CreateAsync(CreateUpdateOrganizationUnitCoordinateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)]
    public virtual Task<OrganizationUnitCoordinateDto> UpdateAsync(Guid id, CreateUpdateOrganizationUnitCoordinateDto input)
    {
        return _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)]
    public virtual Task DeleteAsync(Guid id)
    {
        return _service.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)]
    public virtual Task<OrganizationUnitCoordinateDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    [Authorize(DataPlanePermissions.Dictionaries.OrganizationUnitCoordinate)]
    public virtual Task<PagedResultDto<OrganizationUnitCoordinateDto>> GetListAsync(OrganizationUnitCoordinateGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}