using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;

public class CcicBasicAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicBasicAppService _ccicBasicAppService;

    public CcicBasicAppServiceTests()
    {
        _ccicBasicAppService = GetRequiredService<ICcicBasicAppService>();
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

