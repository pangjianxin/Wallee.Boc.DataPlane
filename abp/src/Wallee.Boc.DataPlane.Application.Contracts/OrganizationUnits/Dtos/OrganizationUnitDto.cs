using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.OrganizationUnits.Dtos
{
    public class OrganizationUnitDto : ExtensibleAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
    }
}
