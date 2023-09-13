using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.Dictionaries;


public class OrganizationUnitCoordinateAppService : CrudAppService<OrganizationUnitCoordinate, OrganizationUnitCoordinateDto, Guid, OrganizationUnitCoordinateGetListInput, CreateUpdateOrganizationUnitCoordinateDto, CreateUpdateOrganizationUnitCoordinateDto>,
    IOrganizationUnitCoordinateAppService
{

    private readonly IOrganizationUnitCoordinateRepository _repository;

    public OrganizationUnitCoordinateAppService(IOrganizationUnitCoordinateRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<OrganizationUnitCoordinate>> CreateFilteredQueryAsync(OrganizationUnitCoordinateGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(input)
            ;
    }
}
