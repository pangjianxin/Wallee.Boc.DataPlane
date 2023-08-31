﻿using Volo.Abp.ObjectExtending;

namespace Wallee.Boc.DataPlane.OrganizationUnits.Dtos
{
    public class OrganizationUnitUpdateDto : ExtensibleObject
    {
        public string DisplayName { get; set; } = null!;
        public string OrgNo { get; set; } = default!;

    }
}
