using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos
{
    public class OrganizationUnitAddRoleDto
    {
        [Required]
        public List<Guid> RoleIds { get; set; } = null!;
    }
}
