using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.Reports.ConvertCusOrgUnits;

public class ConvertedCusOrgUnitRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly IConvertedCusOrgUnitRepository _convertedCusOrgUnitRepository;

    public ConvertedCusOrgUnitRepositoryTests()
    {
        _convertedCusOrgUnitRepository = GetRequiredService<IConvertedCusOrgUnitRepository>();
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
