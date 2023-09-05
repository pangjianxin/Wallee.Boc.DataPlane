using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;

public class TDcmpWorkFlowAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ITDcmpWorkFlowAppService _tDcmpWorkFlowAppService;

    public TDcmpWorkFlowAppServiceTests()
    {
        _tDcmpWorkFlowAppService = GetRequiredService<ITDcmpWorkFlowAppService>();
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

