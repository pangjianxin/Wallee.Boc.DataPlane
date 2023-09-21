using System;
using System.Collections.Generic;
using Volo.Abp.Caching;

namespace Wallee.Boc.DataPlane.Dashboard.Dtos
{
    [CacheName("converted-cus-org-cache")]
    public class ConvertedCusOrgUnitSummary
    {
        public DateTime DataDate { get; set; }
        public IEnumerable<ConvertedCusOrgUnitSummaryItem> Items { get; set; } = default!;
    }

    public class ConvertedCusOrgUnitSummaryItem
    {
        public string? UpOrgidt { get; set; } = default!;
        public string? Orgidt { get; set; } = default!;
        public string? Label { get; set; } = default!;
        public decimal FirstLevel { get; set; }
        public decimal SecondLevel { get; set; }
        public decimal ThirdLevel { get; set; }
        public decimal FourthLevel { get; set; }
        public decimal FifthLevel { get; set; }
        public decimal SixthLevel { get; set; }
    }
}
