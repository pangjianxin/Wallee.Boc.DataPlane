using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    public interface IDataPlaneSettingsAppService : IApplicationService
    {
        Task<DataPlaneSettingsDto> GetDataPlaneSettingsAsync();
        Task UpdateDataPlaneSettingsAsync(UpdateDataPlaneSettingsDto input);
    }
}
