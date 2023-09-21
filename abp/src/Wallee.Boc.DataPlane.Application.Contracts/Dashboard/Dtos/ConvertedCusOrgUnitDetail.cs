using System;
using System.Collections;
using System.Collections.Generic;

namespace Wallee.Boc.DataPlane.Dashboard.Dtos
{
    public class ConvertedCusOrgUnitDetail
    {
        public DateTime DataDate { get; set; }
        public IEnumerable<ConvertedCusOrgUnitDetailItem> Items { get; set; } = default!;
    }
    public class ConvertedCusOrgUnitDetailItem
    {
        public string? Orgidt { get; set; }
        public string? OrgName { get; set; }
        public decimal Value { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
    }
}
