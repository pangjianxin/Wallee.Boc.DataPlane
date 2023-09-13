using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.Dictionaries;

public class OrganizationUnitCoordinateAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly IOrganizationUnitCoordinateAppService _organizationUnitCoordinateAppService;

    public OrganizationUnitCoordinateAppServiceTests()
    {
        _organizationUnitCoordinateAppService = GetRequiredService<IOrganizationUnitCoordinateAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

