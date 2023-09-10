using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;

public class CcicAntiMoneyLaunderingAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicAntiMoneyLaunderingAppService _ccicAntiMoneyLaunderingAppService;

    public CcicAntiMoneyLaunderingAppServiceTests()
    {
        _ccicAntiMoneyLaunderingAppService = GetRequiredService<ICcicAntiMoneyLaunderingAppService>();
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

