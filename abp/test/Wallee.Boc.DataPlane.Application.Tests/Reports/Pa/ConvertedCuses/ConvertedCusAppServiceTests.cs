using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

public class ConvertedCusAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly IConvertedCusAppService _convertedCusAppService;

    public ConvertedCusAppServiceTests()
    {
        _convertedCusAppService = GetRequiredService<IConvertedCusAppService>();
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

