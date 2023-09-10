using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicPractices;

public class CcicPracticeRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicPracticeRepository _ccicPracticeRepository;

    public CcicPracticeRepositoryTests()
    {
        _ccicPracticeRepository = GetRequiredService<ICcicPracticeRepository>();
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
