using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;


[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-basic")]
[Authorize]
public class CcicBasicController : DataPlaneController, ICcicBasicAppService
{
    private readonly ICcicBasicAppService _service;

    public CcicBasicController(ICcicBasicAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{LGPER_CODE}")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicBasic)]
    public virtual Task<CcicBasicDto> GetAsync(CcicBasicKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicBasic)]
    public virtual Task<PagedResultDto<CcicBasicDto>> GetListAsync(CcicBasicGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}