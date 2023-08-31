using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    public interface IBackgroundJobAppService : IApplicationService
    {
        Task<List<BackgroundJobRecordDto>> GetWaitingJobsAsync(int maxCount);
        Task<PagedResultDto<BackgroundJobRecordDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<BackgroundJobRecordDto> GetAsync(Guid id);
        Task<BackgroundJobRecordDto> UpdateAsync(Guid id, BackgroundJobUpdateDto input);
        Task DeleteAsync(Guid id);
    }
}
