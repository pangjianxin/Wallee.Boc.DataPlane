using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicBasics;

public class CcicBasicRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicBasicRepository _ccicBasicRepository;

    public CcicBasicRepositoryTests()
    {
        _ccicBasicRepository = GetRequiredService<ICcicBasicRepository>();
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
