using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;

public class CcicPhoneAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicPhoneAppService _ccicPhoneAppService;

    public CcicPhoneAppServiceTests()
    {
        _ccicPhoneAppService = GetRequiredService<ICcicPhoneAppService>();
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

