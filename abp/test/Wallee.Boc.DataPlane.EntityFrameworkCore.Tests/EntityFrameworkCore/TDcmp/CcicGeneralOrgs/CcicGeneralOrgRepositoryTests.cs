using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicGeneralOrgs;

public class CcicGeneralOrgRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicGeneralOrgRepository _ccicGeneralOrgRepository;

    public CcicGeneralOrgRepositoryTests()
    {
        _ccicGeneralOrgRepository = GetRequiredService<ICcicGeneralOrgRepository>();
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
