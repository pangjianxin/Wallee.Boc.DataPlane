using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicNames;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicNames;

public class CcicNameRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicNameRepository _ccicNameRepository;

    public CcicNameRepositoryTests()
    {
        _ccicNameRepository = GetRequiredService<ICcicNameRepository>();
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
