namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;

public class CcicCustomerTypeAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicCustomerTypeAppService _ccicCustomerTypeAppService;

    public CcicCustomerTypeAppServiceTests()
    {
        _ccicCustomerTypeAppService = GetRequiredService<ICcicCustomerTypeAppService>();
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

