using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public interface IDashboardAppService : IApplicationService
    {
        Task TestAsync();
    }
}
