using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

public class CcicSignOrgAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicSignOrgAppService _ccicSignOrgAppService;

    public CcicSignOrgAppServiceTests()
    {
        _ccicSignOrgAppService = GetRequiredService<ICcicSignOrgAppService>();
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

