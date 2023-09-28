using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

namespace Wallee.Boc.DataPlane.Reports;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/reports/cus-org-adjusment")]
[Authorize]
public class CusOrgAdjusmentController : DataPlaneController, ICusOrgAdjusmentAppService
{
    private readonly ICusOrgAdjusmentAppService _service;

    public CusOrgAdjusmentController(ICusOrgAdjusmentAppService service)
    {
        _service = service;
    }

    [Route("create-by-file")]
    public async Task CreateByFileAsync(CreateUpdateCusOrgAdjusmentByFileDto input)
    {
        await _service.CreateByFileAsync(input);
    }

    [HttpGet]
    [Route("{Cusidt}")]
    public async Task<CusOrgAdjusmentDto> GetAsync(CusOrgAdjusmentKey id)
    {
        return await _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public async Task<PagedResultDto<CusOrgAdjusmentDto>> GetListAsync(CusOrgAdjusmentGetListInput input)
    {
        return await _service.GetListAsync(input);
    }
}