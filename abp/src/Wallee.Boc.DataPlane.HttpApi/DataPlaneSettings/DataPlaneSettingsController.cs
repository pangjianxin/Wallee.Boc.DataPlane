using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/data-plane-settings")]
    [Authorize]
    public class DataPlaneSettingsController : DataPlaneController, IDataPlaneSettingsAppService
    {
        private readonly IDataPlaneSettingsAppService _dataPlaneSettingsAppService;

        public DataPlaneSettingsController(IDataPlaneSettingsAppService dataPlaneSettingsAppService)
        {
            _dataPlaneSettingsAppService = dataPlaneSettingsAppService;
        }

        [HttpGet]
        [Authorize(DataPlanePermissions.Settings.Default)]
        public async Task<DataPlaneSettingsDto> GetDataPlaneSettingsAsync()
        {
            return await _dataPlaneSettingsAppService.GetDataPlaneSettingsAsync();
        }

        [HttpPut]
        [Authorize(DataPlanePermissions.Settings.Default)]
        public async Task UpdateDataPlaneSettingsAsync(UpdateDataPlaneSettingsDto input)
        {
            await _dataPlaneSettingsAppService.UpdateDataPlaneSettingsAsync(input);
        }
    }
}
