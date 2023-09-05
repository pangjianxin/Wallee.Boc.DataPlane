using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;

public class TDcmpWorkFlowRepository : EfCoreRepository<DataPlaneDbContext, TDcmpWorkFlow, Guid>, ITDcmpWorkFlowRepository
{
    public TDcmpWorkFlowRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<TDcmpWorkFlow>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}