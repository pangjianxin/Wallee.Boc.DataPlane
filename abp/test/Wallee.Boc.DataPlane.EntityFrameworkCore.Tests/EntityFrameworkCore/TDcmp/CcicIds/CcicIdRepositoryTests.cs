using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicIds;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicIds;

public class CcicIdRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicIdRepository _ccicIdRepository;

    public CcicIdRepositoryTests()
    {
        _ccicIdRepository = GetRequiredService<ICcicIdRepository>();
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
