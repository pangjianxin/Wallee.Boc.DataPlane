using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;

public class CcicPracticeAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicPracticeAppService _ccicPracticeAppService;

    public CcicPracticeAppServiceTests()
    {
        _ccicPracticeAppService = GetRequiredService<ICcicPracticeAppService>();
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

