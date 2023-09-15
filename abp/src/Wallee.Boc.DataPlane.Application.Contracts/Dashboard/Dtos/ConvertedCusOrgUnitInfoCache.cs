using Volo.Abp.Caching;

namespace Wallee.Boc.DataPlane.Dashboard.Dtos
{
    [CacheName("converted-cus-org-cache")]
    public class ConvertedCusOrgUnitInfoCache
    {
        public string UpOrg { get; set; } = default!;
        public string Org { get; set; } = default!;
        public decimal FirstLevel { get; set; }
        public decimal SecondLevel { get; set; }
        public decimal ThirdLevel { get; set; }
        public decimal FourthLevel { get; set; }
        public decimal FifthLevel { get; set; }
        public decimal SixthLevel { get; set; }
    }
}
