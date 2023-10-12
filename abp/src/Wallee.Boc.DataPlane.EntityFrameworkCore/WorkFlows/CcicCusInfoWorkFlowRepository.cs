using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.WorkFlows;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class CcicCusInfoWorkFlowRepository : EfCoreRepository<DataPlaneDbContext, CcicCusInfoWorkFlow, Guid>, ICcicCusInfoWorkFlowRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
{
    public CcicCusInfoWorkFlowRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicCusInfoWorkFlow>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}