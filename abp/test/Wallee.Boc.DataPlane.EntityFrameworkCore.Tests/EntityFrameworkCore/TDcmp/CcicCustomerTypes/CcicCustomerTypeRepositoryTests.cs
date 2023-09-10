using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicCustomerTypes;

public class CcicCustomerTypeRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicCustomerTypeRepository _ccicCustomerTypeRepository;

    public CcicCustomerTypeRepositoryTests()
    {
        _ccicCustomerTypeRepository = GetRequiredService<ICcicCustomerTypeRepository>();
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
