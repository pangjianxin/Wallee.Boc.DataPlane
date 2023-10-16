using Volo.Abp.Caching;

namespace Wallee.Boc.DataPlane.RulesEngines
{
    [CacheName("converted-cus-filter-rules")]
    public class ConvertedCusFilterRulesCache
    {
        public string? Rules { get; set; } = default!;
    }
}
