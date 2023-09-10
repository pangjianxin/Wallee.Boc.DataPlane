using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicAntiMoneyLaunderings;

public class CcicAntiMoneyLaunderingRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicAntiMoneyLaunderingRepository _ccicAntiMoneyLaunderingRepository;

    public CcicAntiMoneyLaunderingRepositoryTests()
    {
        _ccicAntiMoneyLaunderingRepository = GetRequiredService<ICcicAntiMoneyLaunderingRepository>();
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
