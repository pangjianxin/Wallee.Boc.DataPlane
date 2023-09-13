using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Dictionaries;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.Dictionaries;

public class OrganizationUnitCoordinateRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly IOrganizationUnitCoordinateRepository _organizationUnitCoordinateRepository;

    public OrganizationUnitCoordinateRepositoryTests()
    {
        _organizationUnitCoordinateRepository = GetRequiredService<IOrganizationUnitCoordinateRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
