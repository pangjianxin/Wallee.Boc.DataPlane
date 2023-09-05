using Shouldly;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddress;

public class CcicAddressAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicAddressAppService _ccicAddressAppService;

    public CcicAddressAppServiceTests()
    {
        _ccicAddressAppService = GetRequiredService<ICcicAddressAppService>();
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

