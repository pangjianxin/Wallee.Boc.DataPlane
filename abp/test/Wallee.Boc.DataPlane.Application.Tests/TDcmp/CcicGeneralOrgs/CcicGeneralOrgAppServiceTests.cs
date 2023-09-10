using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;

public class CcicGeneralOrgAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicGeneralOrgAppService _ccicGeneralOrgAppService;

    public CcicGeneralOrgAppServiceTests()
    {
        _ccicGeneralOrgAppService = GetRequiredService<ICcicGeneralOrgAppService>();
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

