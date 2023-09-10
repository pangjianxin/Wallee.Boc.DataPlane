using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

public class CcicRegisterAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicRegisterAppService _ccicRegisterAppService;

    public CcicRegisterAppServiceTests()
    {
        _ccicRegisterAppService = GetRequiredService<ICcicRegisterAppService>();
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

