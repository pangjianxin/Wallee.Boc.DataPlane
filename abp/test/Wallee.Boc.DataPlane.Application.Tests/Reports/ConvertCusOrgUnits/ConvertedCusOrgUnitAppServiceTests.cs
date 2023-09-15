using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

public class ConvertedCusOrgUnitAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly IConvertedCusOrgUnitAppService _convertedCusOrgUnitAppService;

    public ConvertedCusOrgUnitAppServiceTests()
    {
        _convertedCusOrgUnitAppService = GetRequiredService<IConvertedCusOrgUnitAppService>();
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

