using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicSignOrgs;

public class CcicSignOrgRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicSignOrgRepository _ccicSignOrgRepository;

    public CcicSignOrgRepositoryTests()
    {
        _ccicSignOrgRepository = GetRequiredService<ICcicSignOrgRepository>();
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
