using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.RulesEngines
{
    public class RulesEngineProvider : DataPlaneAppService, IRulesEngineProvider, ITransientDependency
    {
        private readonly IDistributedCache<ConvertedCusFilterRulesCache> _convertedCusFilterCache;

        public RulesEngineProvider(IDistributedCache<ConvertedCusFilterRulesCache> convertedCusFilterCache)
        {
            _convertedCusFilterCache = convertedCusFilterCache;
        }
        public async Task<ConvertedCusFilterRulesCache> GetOrAddConvertedCusFilterAsync()
        {
            return (await _convertedCusFilterCache.GetOrAddAsync("converted-cus-filter",
                GetConvertedCusFilterRulesFromSettingsAsync,
                () => new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(6)
                }))!;

            async Task<ConvertedCusFilterRulesCache> GetConvertedCusFilterRulesFromSettingsAsync()
            {
                return new ConvertedCusFilterRulesCache { Rules = await SettingProvider.GetOrNullAsync(Settings.DataPlaneSettings.ConvertedCusFilterRules) };
            }

        }
    }
}
