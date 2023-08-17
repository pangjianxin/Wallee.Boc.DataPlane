using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Wallee.Boc.DataPlane.Pages;

public class Index_Tests : DataPlaneWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
