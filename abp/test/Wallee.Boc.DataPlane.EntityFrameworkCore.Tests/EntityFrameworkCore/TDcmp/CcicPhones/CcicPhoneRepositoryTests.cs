using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicPhones;

public class CcicPhoneRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicPhoneRepository _ccicPhoneRepository;

    public CcicPhoneRepositoryTests()
    {
        _ccicPhoneRepository = GetRequiredService<ICcicPhoneRepository>();
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
