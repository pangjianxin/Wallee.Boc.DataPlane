using Wallee.Boc.DataPlane.TDcmp.CcicAddresses;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicAddress;

public class CcicAddressRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicAddressRepository _ccicAddressRepository;

    public CcicAddressRepositoryTests()
    {
        _ccicAddressRepository = GetRequiredService<ICcicAddressRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
