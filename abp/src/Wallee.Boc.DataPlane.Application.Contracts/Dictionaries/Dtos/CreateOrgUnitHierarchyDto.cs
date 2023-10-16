using System;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class CreateOrgUnitHierarchyDto
{
    public Guid? ParentId { get; set; }

    public string OrgIdentity { get; set; } = default!;

    public string Name { get; set; } = default!;
}