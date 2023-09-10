using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;

public class CcicCustomerTypeOrgAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicCustomerTypeOrgAppService _ccicCustomerTypeOrgAppService;

    public CcicCustomerTypeOrgAppServiceTests()
    {
        _ccicCustomerTypeOrgAppService = GetRequiredService<ICcicCustomerTypeOrgAppService>();
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

