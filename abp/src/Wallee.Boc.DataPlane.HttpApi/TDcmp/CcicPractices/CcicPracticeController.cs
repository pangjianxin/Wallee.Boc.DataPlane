using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPractices.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-practice")]
[Authorize]
public class CcicPracticeController : DataPlaneController, ICcicPracticeAppService
{
    private readonly ICcicPracticeAppService _service;

    public CcicPracticeController(ICcicPracticeAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{OPRT_INF_SN}/{LGPER_CODE}")]
    public virtual Task<CcicPracticeDto> GetAsync(CcicPracticeKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public virtual Task<PagedResultDto<CcicPracticeDto>> GetListAsync(CcicPracticeGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}