using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;

namespace Wallee.Boc.DataPlane.Reports
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/converted-cus-org-unit")]
    [Authorize]
    public class ConvertedCusOrgUnitController : DataPlaneController, IConvertedCusOrgUnitAppService
    {
        private readonly IConvertedCusOrgUnitAppService _convertedCusOrgUnitAppService;

        public ConvertedCusOrgUnitController(IConvertedCusOrgUnitAppService convertedCusOrgUnitAppService)
        {
            _convertedCusOrgUnitAppService = convertedCusOrgUnitAppService;
        }

        [HttpPost]
        [Route("create-by-file")]
        public async Task CreateByFileAsync(CreateUpdateConvertedCusOrgUnitByFileDto input)
        {
            await _convertedCusOrgUnitAppService.CreateByFileAsync(input);
        }

        [HttpGet]
        [Route("{DataDate}/{Orgidt}")]
        public async Task<ConvertedCusOrgUnitDto> GetAsync(ConvertedCusOrgUnitKey id)
        {
            return await _convertedCusOrgUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedResultDto<ConvertedCusOrgUnitDto>> GetListAsync(ConvertedCusOrgUnitGetListInput input)
        {
            return await _convertedCusOrgUnitAppService.GetListAsync(input);
        }
    }
}
