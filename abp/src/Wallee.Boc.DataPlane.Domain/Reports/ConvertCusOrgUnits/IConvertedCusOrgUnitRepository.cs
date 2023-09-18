using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
public interface IConvertedCusOrgUnitRepository : IRepository<ConvertedCusOrgUnit>
{
    Task<DateTime> GetCurrentDataDate();
    Task UpsertAsync(IEnumerable<ConvertedCusOrgUnit> convertedCusOrgUnits);
}
