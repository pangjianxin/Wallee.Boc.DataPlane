using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;

public class CcicLsolationListAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicLsolationListAppService _ccicLsolationListAppService;

    public CcicLsolationListAppServiceTests()
    {
        _ccicLsolationListAppService = GetRequiredService<ICcicLsolationListAppService>();
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

