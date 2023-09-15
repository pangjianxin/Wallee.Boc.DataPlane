using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public interface IDashboardAppService : IApplicationService
    {
        public Task GetConvertedCusOrgUnitInfoAsync(DateTime dataDate);
    }
}
