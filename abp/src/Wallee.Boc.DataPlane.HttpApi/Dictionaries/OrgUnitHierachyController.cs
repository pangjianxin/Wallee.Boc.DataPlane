using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/app/dictionaries/org-unit-hierarchy")]
    [Authorize]
    public class OrgUnitHierachyController : DataPlaneController, IOrgUnitHierarchyAppService
    {
        private readonly IOrgUnitHierarchyAppService _orgUnitHierachyAppService;

        public OrgUnitHierachyController(IOrgUnitHierarchyAppService orgUnitHierachyAppService)
        {
            _orgUnitHierachyAppService = orgUnitHierachyAppService;
        }

        [HttpPost]
        [Route("")]
        public async Task<OrgUnitHierarchyDto> CreateAsync(CreateOrgUnitHierarchyDto input)
        {
            return await _orgUnitHierachyAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _orgUnitHierachyAppService.DeleteAsync(id);
        }
        [HttpGet]
        [Route("all")]
        public async Task<List<OrgUnitHierarchyDto>> GetAllAsync()
        {
            return await _orgUnitHierachyAppService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OrgUnitHierarchyDto> GetAsync(Guid id)
        {
            return await _orgUnitHierachyAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedResultDto<OrgUnitHierarchyDto>> GetListAsync(OrgUnitHierarchyGetListInput input)
        {
            return await _orgUnitHierachyAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("move/{id}")]
        public async Task<OrgUnitHierarchyDto> MoveAsync(Guid id, MoveOrgUnitHierarchyDto input)
        {
            return await _orgUnitHierachyAppService.MoveAsync(id, input);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<OrgUnitHierarchyDto> UpdateAsync(Guid id, UpdateOrgUnitHierarchyDto input)
        {
            return await _orgUnitHierachyAppService.UpdateAsync(id, input);
        }
    }
}
