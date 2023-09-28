using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

public class CusOrgAdjusmentAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICusOrgAdjusmentAppService _cusOrgAdjusmentAppService;

    public CusOrgAdjusmentAppServiceTests()
    {
        _cusOrgAdjusmentAppService = GetRequiredService<ICusOrgAdjusmentAppService>();
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

