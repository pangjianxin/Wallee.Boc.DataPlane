using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Caches;

namespace Wallee.Boc.DataPlane.Identity.OrganizationUnits.Events
{
    public class OrganizationUnitEventHandler :
        IDistributedEventHandler<EntityUpdatedEto<OrganizationUnitEto>>,
        IDistributedEventHandler<EntityCreatedEto<OrganizationUnitEto>>,
        IDistributedEventHandler<EntityDeletedEto<OrganizationUnitEto>>,
        ITransientDependency
    {
        private readonly IOrganizationUnitCacheProvider _organizationUnitCacheProvider;

        public OrganizationUnitEventHandler(IOrganizationUnitCacheProvider organizationUnitCacheProvider)
        {
            _organizationUnitCacheProvider = organizationUnitCacheProvider;
        }
        public async Task HandleEventAsync(EntityUpdatedEto<OrganizationUnitEto> eventData)
        {
            await _organizationUnitCacheProvider.RefreshAsync();
        }

        public async Task HandleEventAsync(EntityCreatedEto<OrganizationUnitEto> eventData)
        {
            await _organizationUnitCacheProvider.RefreshAsync();
        }

        public async Task HandleEventAsync(EntityDeletedEto<OrganizationUnitEto> eventData)
        {
            await _organizationUnitCacheProvider.RefreshAsync();
        }
    }
}
