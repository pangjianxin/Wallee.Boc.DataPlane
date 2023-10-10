using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-phone")]
[Authorize]
public class CcicPhoneController : DataPlaneController, ICcicPhoneAppService
{
    private readonly ICcicPhoneAppService _service;

    public CcicPhoneController(ICcicPhoneAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{UNIT_TEL_TP}/{CNTEL_SN}/{LGPER_CODE}")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicPhone)]
    public virtual Task<CcicPhoneDto> GetAsync(CcicPhoneKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicPhone)]
    public virtual Task<PagedResultDto<CcicPhoneDto>> GetListAsync(CcicPhoneGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}