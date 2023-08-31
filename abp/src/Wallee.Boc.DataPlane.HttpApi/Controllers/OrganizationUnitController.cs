using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Wallee.Boc.DataPlane.OrganizationUnits;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.Controllers
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/identity/organization-units")]
    [Authorize(DataPlanePermissions.OrganizationUnits.Default)]
    public class OrganizationUnitController : DataPlaneController, IOrganizationUnitAppService
    {
        protected IOrganizationUnitAppService OrganizationUnitAppService { get; }

        public OrganizationUnitController(
            IOrganizationUnitAppService organizationUnitAppService)
        {
            OrganizationUnitAppService = organizationUnitAppService;
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.Create)]
        [HttpPost]
        public async virtual Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            return await OrganizationUnitAppService.CreateAsync(input);
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async virtual Task DeleteAsync(Guid id)
        {
            await OrganizationUnitAppService.DeleteAsync(id);
        }


        [HttpGet]
        [Route("find-children")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> FindChildrenAsync(OrganizationUnitGetChildrenDto input)
        {
            return await OrganizationUnitAppService.FindChildrenAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public async virtual Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            return await OrganizationUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("root-node")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetRootAsync()
        {
            return await OrganizationUnitAppService.GetRootAsync();
        }

        [HttpGet]
        [Route("last-children")]
        public async virtual Task<OrganizationUnitDto> GetLastChildOrNullAsync(Guid? parentId)
        {
            return await OrganizationUnitAppService.GetLastChildOrNullAsync(parentId);
        }

        [HttpGet]
        [Route("all")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync()
        {
            return await OrganizationUnitAppService.GetAllListAsync();
        }

        [HttpGet]
        public async virtual Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitGetListInput input)
        {
            return await OrganizationUnitAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}/role-names")]
        public async virtual Task<ListResultDto<string>> GetRoleNamesAsync(Guid id)
        {
            return await OrganizationUnitAppService.GetRoleNamesAsync(id);
        }

        [HttpGet]
        [Route("{id}/unadded-roles")]
        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetUnaddedRolesAsync(Guid id, OrganizationUnitGetUnaddedRoleListInput input)
        {
            return await OrganizationUnitAppService.GetUnaddedRolesAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/roles")]
        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input)
        {
            return await OrganizationUnitAppService.GetRolesAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/unadded-users")]
        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUnaddedUsersAsync(Guid id, OrganizationUnitGetUnaddedUserListInput input)
        {
            return await OrganizationUnitAppService.GetUnaddedUsersAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/users")]
        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUsersAsync(Guid id, GetIdentityUsersInput input)
        {
            return await OrganizationUnitAppService.GetUsersAsync(id, input);
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.ManageUsers)]
        [HttpPost]
        [Route("{id}/users")]
        public async virtual Task AddUsersAsync(Guid id, OrganizationUnitAddUserDto input)
        {
            await OrganizationUnitAppService.AddUsersAsync(id, input);
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.ManageRoles)]
        [HttpPost]
        [Route("{id}/roles")]
        public async virtual Task AddRolesAsync(Guid id, OrganizationUnitAddRoleDto input)
        {
            await OrganizationUnitAppService.AddRolesAsync(id, input);
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.Update)]
        [HttpPut]
        [Route("{id}/move")]
        public async virtual Task MoveAsync(Guid id, OrganizationUnitMoveDto input)
        {
            await OrganizationUnitAppService.MoveAsync(id, input);
        }

        [Authorize(DataPlanePermissions.OrganizationUnits.Update)]
        [HttpPut]
        [Route("{id}")]
        public async virtual Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            return await OrganizationUnitAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{organizationUnitId}/roles/{roleId}")]
        public async Task DeleteRoleAsync(Guid organizationUnitId, Guid roleId)
        {
            await OrganizationUnitAppService.DeleteRoleAsync(organizationUnitId, roleId);
        }

        [HttpDelete]
        [Route("{organizationUnitId}/users/{userId}")]
        public async Task DeleteUserAsync(Guid organizationUnitId, Guid userId)
        {
            await OrganizationUnitAppService.DeleteUserAsync(organizationUnitId, userId);
        }
    }
}
