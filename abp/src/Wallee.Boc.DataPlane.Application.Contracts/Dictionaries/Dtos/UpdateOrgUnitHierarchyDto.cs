using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos
{
    public class UpdateOrgUnitHierarchyDto : IHasConcurrencyStamp
    {
        public string Name { get; set; } = default!;
        public string Identity { get; set; } = default!;
        public string ConcurrencyStamp { get; set; } = default!;
    }
}
