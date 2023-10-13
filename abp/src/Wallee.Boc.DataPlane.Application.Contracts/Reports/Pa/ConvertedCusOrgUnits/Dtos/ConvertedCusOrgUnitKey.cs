using System;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos
{
    public class ConvertedCusOrgUnitKey
    {
        public DateTime DataDate { get; private set; } = default!;
        public string OrgIdentity { get; private set; } = default!;
    }
}
