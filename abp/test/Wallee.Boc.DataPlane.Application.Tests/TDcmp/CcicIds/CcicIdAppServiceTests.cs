using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;

public class CcicIdAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicIdAppService _ccicIdAppService;

    public CcicIdAppServiceTests()
    {
        _ccicIdAppService = GetRequiredService<ICcicIdAppService>();
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

