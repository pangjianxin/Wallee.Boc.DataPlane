using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicLsolationLists;

public class CcicLsolationListRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicLsolationListRepository _ccicLsolationListRepository;

    public CcicLsolationListRepositoryTests()
    {
        _ccicLsolationListRepository = GetRequiredService<ICcicLsolationListRepository>();
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
