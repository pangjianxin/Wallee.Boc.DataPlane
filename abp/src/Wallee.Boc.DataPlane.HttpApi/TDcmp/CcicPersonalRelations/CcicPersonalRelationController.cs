using System;
using Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;

[RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
[Route("/api/app/t-dcmp/ccic-personal-relation")]
[Authorize]
public class CcicPersonalRelationController : DataPlaneController, ICcicPersonalRelationAppService
{
    private readonly ICcicPersonalRelationAppService _service;

    public CcicPersonalRelationController(ICcicPersonalRelationAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{CUSNO}/{REL_RL}/{PRINT_CUSNO_YARD}/{LGPER_CODE}")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicPersonalRelation)]
    public virtual Task<CcicPersonalRelationDto> GetAsync(CcicPersonalRelationKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    [Authorize(DataPlanePermissions.TDcmpReports.CcicPersonalRelation)]
    public virtual Task<PagedResultDto<CcicPersonalRelationDto>> GetListAsync(CcicPersonalRelationGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}