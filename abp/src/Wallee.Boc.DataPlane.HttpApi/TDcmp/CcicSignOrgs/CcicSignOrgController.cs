using System;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-sign-org")]
[Authorize]
public class CcicSignOrgController : DataPlaneController, ICcicSignOrgAppService
{
    private readonly ICcicSignOrgAppService _service;

    public CcicSignOrgController(ICcicSignOrgAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{LGPER_CODE}")]
    public virtual Task<CcicSignOrgDto> GetAsync(CcicSignOrgKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public virtual Task<PagedResultDto<CcicSignOrgDto>> GetListAsync(CcicSignOrgGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}