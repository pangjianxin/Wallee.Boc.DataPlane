using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

namespace Wallee.Boc.DataPlane.Reports
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/reports/converted-cus")]
    [Authorize]
    public class ConvertedCusController : DataPlaneController, IConvertedCusAppService
    {
        private readonly IConvertedCusAppService _convertedCusAppService;

        public ConvertedCusController(IConvertedCusAppService convertedCusAppService)
        {
            _convertedCusAppService = convertedCusAppService;
        }

        [Route("create-by-file")]
        public async Task CreateByFileAsync(CreateUpdateConvertedCusByFileDto input)
        {
            await _convertedCusAppService.CreateByFileAsync(input);
        }

        [HttpGet]
        [Route("{DataDate}/{Cusidt}")]
        public async Task<ConvertedCusDto> GetAsync(ConvertedCusKey id)
        {
            return await _convertedCusAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedResultDto<ConvertedCusDto>> GetListAsync(ConvertedCusGetListInput input)
        {
            return await _convertedCusAppService.GetListAsync(input);
        }
    }
}
