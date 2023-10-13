using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.Dictionaries;

public class OrgUnitHierachyAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly IOrgUnitHierachyAppService _orgUnitHierachyAppService;

    public OrgUnitHierachyAppServiceTests()
    {
        _orgUnitHierachyAppService = GetRequiredService<IOrgUnitHierachyAppService>();
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

