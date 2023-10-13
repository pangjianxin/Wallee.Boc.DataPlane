using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class ConvertedCusRepository : UpsertableEfCoreRepository<ConvertedCus>, IConvertedCusRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
{
    public ConvertedCusRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider, IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }

    public IClock Clock { get; }

    public override async Task<IQueryable<ConvertedCus>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}