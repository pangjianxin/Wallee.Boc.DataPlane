using System;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos
{
    public class ConvertedCusOrgUnitKey
    {
        public DateTime DataDate { get; private set; } = default!;
        public string Orgidt { get; private set; } = default!;
    }
}
