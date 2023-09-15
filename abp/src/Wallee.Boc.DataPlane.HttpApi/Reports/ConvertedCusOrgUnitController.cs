using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Task<ConvertedCusOrgUnitDto> CreateAsync(CreateUpdateConvertedCusOrgUnitDto input)
        {
            return _convertedCusOrgUnitAppService.CreateAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _convertedCusOrgUnitAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ConvertedCusOrgUnitDto> GetAsync(Guid id)
        {
            return await _convertedCusOrgUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedResultDto<ConvertedCusOrgUnitDto>> GetListAsync(ConvertedCusOrgUnitGetListInput input)
        {
            return await _convertedCusOrgUnitAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ConvertedCusOrgUnitDto> UpdateAsync(Guid id, CreateUpdateConvertedCusOrgUnitDto input)
        {
            return await _convertedCusOrgUnitAppService.UpdateAsync(id, input);
        }
    }
}
