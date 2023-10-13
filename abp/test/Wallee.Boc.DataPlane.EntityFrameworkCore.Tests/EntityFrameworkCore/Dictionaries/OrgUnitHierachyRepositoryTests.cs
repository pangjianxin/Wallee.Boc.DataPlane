using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Dictionaries;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.Dictionaries;

public class OrgUnitHierachyRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly IOrgUnitHierachyRepository _orgUnitHierachyRepository;

    public OrgUnitHierachyRepositoryTests()
    {
        _orgUnitHierachyRepository = GetRequiredService<IOrgUnitHierachyRepository>();
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
