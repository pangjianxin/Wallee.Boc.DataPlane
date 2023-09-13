using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries;

[RemoteService(Name = "Default")]
[Route("/api/app/dictionaries/organization-unit-coordinate")]
public class OrganizationUnitCoordinateController : DataPlaneController, IOrganizationUnitCoordinateAppService
{
    private readonly IOrganizationUnitCoordinateAppService _service;

    public OrganizationUnitCoordinateController(IOrganizationUnitCoordinateAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
    public virtual Task<OrganizationUnitCoordinateDto> CreateAsync(CreateUpdateOrganizationUnitCoordinateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public virtual Task<OrganizationUnitCoordinateDto> UpdateAsync(Guid id, CreateUpdateOrganizationUnitCoordinateDto input)
    {
        return _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return _service.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<OrganizationUnitCoordinateDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public virtual Task<PagedResultDto<OrganizationUnitCoordinateDto>> GetListAsync(OrganizationUnitCoordinateGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}