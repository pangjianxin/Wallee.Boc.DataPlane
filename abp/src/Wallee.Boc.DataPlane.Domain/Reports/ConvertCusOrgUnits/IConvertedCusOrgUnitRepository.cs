using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;

/// <summary>
/// 折效客户机构分布情况
/// </summary>
public interface IConvertedCusOrgUnitRepository : IRepository<ConvertedCusOrgUnit, Guid>
{
}
