using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicCustomerTypeOrgs;

public class CcicCustomerTypeOrgRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicCustomerTypeOrgRepository _ccicCustomerTypeOrgRepository;

    public CcicCustomerTypeOrgRepositoryTests()
    {
        _ccicCustomerTypeOrgRepository = GetRequiredService<ICcicCustomerTypeOrgRepository>();
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
