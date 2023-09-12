using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/data-plane-settings")]
    public class DataPlaneSettingsController : DataPlaneController, IDataPlaneSettingsAppService
    {
        private readonly IDataPlaneSettingsAppService _dataPlaneSettingsAppService;

        public DataPlaneSettingsController(IDataPlaneSettingsAppService dataPlaneSettingsAppService)
        {
            _dataPlaneSettingsAppService = dataPlaneSettingsAppService;
        }

        [HttpGet]
        public async Task<DataPlaneSettingsDto> GetDataPlaneSettingsAsync()
        {
            return await _dataPlaneSettingsAppService.GetDataPlaneSettingsAsync();
        }

        [HttpPut]
        public async Task UpdateDataPlaneSettingsAsync(UpdateDataPlaneSettingsDto input)
        {
            await _dataPlaneSettingsAppService.UpdateDataPlaneSettingsAsync(input);
        }
    }
}
