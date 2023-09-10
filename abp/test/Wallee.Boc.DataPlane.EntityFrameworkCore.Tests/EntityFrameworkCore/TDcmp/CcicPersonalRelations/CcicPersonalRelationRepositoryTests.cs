using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.CcicPersonalRelations;

public class CcicPersonalRelationRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ICcicPersonalRelationRepository _ccicPersonalRelationRepository;

    public CcicPersonalRelationRepositoryTests()
    {
        _ccicPersonalRelationRepository = GetRequiredService<ICcicPersonalRelationRepository>();
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
