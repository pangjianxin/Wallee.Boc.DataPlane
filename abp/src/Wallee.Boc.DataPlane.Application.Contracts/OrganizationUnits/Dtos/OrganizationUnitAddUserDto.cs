using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.OrganizationUnits.Dtos
{
    public class OrganizationUnitAddUserDto
    {
        [Required]
        public List<Guid> UserIds { get; set; } = null!;
    }
}
