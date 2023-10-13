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

#pragma warning disable CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
public class ConvertedCusOrgUnitRepository : UpsertableEfCoreRepository<ConvertedCusOrgUnit>, IConvertedCusOrgUnitRepository
#pragma warning restore CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣

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