using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.Dictionaries;

/// <summary>
/// 机构层级表
/// </summary>
public interface IOrgUnitHierarchyRepository : IRepository<OrgUnitHierarchy, Guid>
{
}
