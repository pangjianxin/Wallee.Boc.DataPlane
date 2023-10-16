using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

/// <summary>
/// 机构层级表
/// </summary>
[Serializable]
public class OrgUnitHierarchyDto : AuditedEntityDto<Guid>, IHasConcurrencyStamp
{
    public Guid? ParentId { get; set; }

    public string OrgIdentity { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string ConcurrencyStamp { get; set; } = default!;
}