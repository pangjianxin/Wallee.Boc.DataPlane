using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Wallee.Boc.DataPlane.EntityFrameworkCore.TDcmp.WorkFlows;

public class TDcmpWorkFlowRepositoryTests : DataPlaneEntityFrameworkCoreTestBase
{
    private readonly ITDcmpWorkFlowRepository _tDcmpWorkFlowRepository;

    public TDcmpWorkFlowRepositoryTests()
    {
        _tDcmpWorkFlowRepository = GetRequiredService<ITDcmpWorkFlowRepository>();
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
