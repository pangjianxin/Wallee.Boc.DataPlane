using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.Reports.Pa.ConvertedCuses;

public class CusOrgAdjusmentRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICusOrgAdjusmentRepository _cusOrgAdjusmentRepository;

    public CusOrgAdjusmentRepositoryTests()
    {
        _cusOrgAdjusmentRepository = GetRequiredService<ICusOrgAdjusmentRepository>();
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
