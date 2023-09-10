using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicRegisters;

public class CcicRegisterRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicRegisterRepository _ccicRegisterRepository;

    public CcicRegisterRepositoryTests()
    {
        _ccicRegisterRepository = GetRequiredService<ICcicRegisterRepository>();
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
