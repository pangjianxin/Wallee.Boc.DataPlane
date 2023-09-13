using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Dictionaries;

public interface IOrganizationUnitCoordinateRepository : IRepository<OrganizationUnitCoordinate, Guid>
{
}
