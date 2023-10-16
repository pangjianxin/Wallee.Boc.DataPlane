using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.RulesEngines
{
    public interface IRulesEngineProvider : ITransientDependency
    {
        public Task<ConvertedCusFilterRulesCache> GetOrAddConvertedCusFilterAsync();
    }
}
