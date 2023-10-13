using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertCusOrgUnits;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class ConvertedCusOrgUnitRepository : UpsertableEfCoreRepository<ConvertedCusOrgUnit>, IConvertedCusOrgUnitRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。

{
    public IClock Clock { get; }

    public ConvertedCusOrgUnitRepository(
        IDbContextProvider<DataPlaneDbContext> dbContextProvider,
        IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }

    public async Task<DateTime> GetCurrentDataDate()
    {
        return await (await GetDbSetAsync()).MaxAsync(it => it.DataDate);
    }

    public override async Task<IQueryable<ConvertedCusOrgUnit>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}