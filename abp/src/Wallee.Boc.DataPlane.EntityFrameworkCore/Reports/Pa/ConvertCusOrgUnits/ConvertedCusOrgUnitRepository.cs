using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertCusOrgUnits;

public class ConvertedCusOrgUnitRepository : EfCoreRepository<DataPlaneDbContext, ConvertedCusOrgUnit>, IConvertedCusOrgUnitRepository
{
    public ConvertedCusOrgUnitRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task UpsertAsync(IEnumerable<ConvertedCusOrgUnit> convertedCusOrgUnits)
    {
        await (await GetDbSetAsync()).UpsertRange(convertedCusOrgUnits)
            .On(it => new { it.DataDate, it.Orgidt })
            .WhenMatched((origin, cur) => new ConvertedCusOrgUnit
            {
                Label = cur.Label,
                UpOrgidt = cur.UpOrgidt,
                Orgidt = cur.Orgidt,
                DataDate = cur.DataDate,
                FirstLevel = cur.FirstLevel,
                SecondLevel = cur.SecondLevel,
                ThirdLevel = cur.ThirdLevel,
                FourthLevel = cur.FourthLevel,
                FifthLevel = cur.FifthLevel,
                SixthLevel = cur.SixthLevel
            })
            .RunAsync();
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