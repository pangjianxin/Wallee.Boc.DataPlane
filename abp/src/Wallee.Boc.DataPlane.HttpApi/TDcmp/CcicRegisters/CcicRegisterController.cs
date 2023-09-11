using System;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-register")]
[Authorize]
public class CcicRegisterController : DataPlaneController, ICcicRegisterAppService
{
    private readonly ICcicRegisterAppService _service;

    public CcicRegisterController(ICcicRegisterAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{LGPER_CODE}")]
    public virtual Task<CcicRegisterDto> GetAsync(CcicRegisterKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public virtual Task<PagedResultDto<CcicRegisterDto>> GetListAsync(CcicRegisterGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}