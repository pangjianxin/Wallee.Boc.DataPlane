using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.WorkFlows;

public class CcicCusInfoWorkFlowRepository : EfCoreRepository<DataPlaneDbContext, CcicCusInfoWorkFlow, Guid>, ICcicCusInfoWorkFlowRepository
{
    public CcicCusInfoWorkFlowRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicCusInfoWorkFlow>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}