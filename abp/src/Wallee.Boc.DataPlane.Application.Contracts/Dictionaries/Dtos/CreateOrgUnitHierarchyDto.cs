using System;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class CreateOrgUnitHierarchyDto
{
    public Guid? ParentId { get; set; }

    public string Identity { get; set; } = default!;

    public string Name { get; set; } = default!;
}