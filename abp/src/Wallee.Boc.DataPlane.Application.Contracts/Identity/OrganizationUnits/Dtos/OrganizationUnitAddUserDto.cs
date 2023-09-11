using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos
{
    public class OrganizationUnitAddUserDto
    {
        [Required]
        public List<Guid> UserIds { get; set; } = null!;
    }
}
