using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;

public class CcicPersonalRelationAppServiceTests : DataPlaneApplicationTestBase
{
    private readonly ICcicPersonalRelationAppService _ccicPersonalRelationAppService;

    public CcicPersonalRelationAppServiceTests()
    {
        _ccicPersonalRelationAppService = GetRequiredService<ICcicPersonalRelationAppService>();
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

