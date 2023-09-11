using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Wallee.Boc.DataPlane.Permissions;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    [RemoteService(Name = DataPlaneRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/backgroundJobs")]
    [Authorize]
    public class BackgroundJobController : DataPlaneController, IBackgroundJobAppService
    {
        private readonly IBackgroundJobAppService _backgroundJobAppService;

        public BackgroundJobController(IBackgroundJobAppService backgroundJobAppService)
        {
            _backgroundJobAppService = backgroundJobAppService;
        }

        [HttpDelete]
        [Authorize(DataPlanePermissions.BackgroundJobs.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _backgroundJobAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(DataPlanePermissions.BackgroundJobs.Default)]
        public async Task<BackgroundJobRecordDto> GetAsync(Guid id)
        {
            return await _backgroundJobAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(DataPlanePermissions.BackgroundJobs.Default)]
        public async Task<PagedResultDto<BackgroundJobRecordDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await _backgroundJobAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("getWaitingJobs")]
        [Authorize(DataPlanePermissions.BackgroundJobs.Default)]
        public async Task<List<BackgroundJobRecordDto>> GetWaitingJobsAsync(int maxCount)
        {
            return await _backgroundJobAppService.GetWaitingJobsAsync(maxCount);
        }

        [HttpPut]
        [Authorize(DataPlanePermissions.BackgroundJobs.Update)]
        public async Task<BackgroundJobRecordDto> UpdateAsync(Guid id, BackgroundJobUpdateDto input)
        {
            return await _backgroundJobAppService.UpdateAsync(id, input);
        }
    }
}
