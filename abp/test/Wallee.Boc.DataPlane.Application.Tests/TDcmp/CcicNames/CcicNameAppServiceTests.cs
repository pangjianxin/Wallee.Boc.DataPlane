using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;

public class CcicNameAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicNameAppService _ccicNameAppService;

    public CcicNameAppServiceTests()
    {
        _ccicNameAppService = GetRequiredService<ICcicNameAppService>();
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

