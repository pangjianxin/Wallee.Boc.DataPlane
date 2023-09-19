using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.Dashboard.Dtos;

namespace Wallee.Boc.DataPlane.Dashboard
{
    public interface IDashboardAppService : IApplicationService
    {
        Task<ConvertedCusOrgUnitDetail?> GetConvertedCusOrgUnitDetailsAsync(GetConvertedCusOrgUnitDetailsDto input);
        public Task<ConvertedCusOrgUnitSummary?> GetConvertedCusOrgUnitSummaryAsync(DateTime? dataDate);
    }
}
