using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class CusOrgAdjusmentRepository : UpsertableEfCoreRepository<CusOrgAdjusment>, ICusOrgAdjusmentRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
{
    public IClock Clock { get; set; }

    public CusOrgAdjusmentRepository(
        IDbContextProvider<DataPlaneDbContext> dbContextProvider,
        IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }
    public override async Task<IQueryable<CusOrgAdjusment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}