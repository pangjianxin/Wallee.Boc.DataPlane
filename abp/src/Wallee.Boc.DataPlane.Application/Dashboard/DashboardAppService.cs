using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public class DashboardAppService : DataPlaneAppService, IDashboardAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public DashboardAppService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }

        public async Task TestAsync()
        {
            await _backgroundJobManager.EnqueueAsync(new FirstJobArgs());
        }
    }
}
