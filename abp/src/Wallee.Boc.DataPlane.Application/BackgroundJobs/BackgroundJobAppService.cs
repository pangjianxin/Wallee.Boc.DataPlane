using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    public class BackgroundJobAppService : DataPlaneAppService, IBackgroundJobAppService, ITransientDependency
    {
        public IBackgroundJobRepository BackgroundJobRepository { get; }
        public ILocalEventBus LocalEventBus { get; }
        public IBackgroundJobManager BackgroundJobManager { get; }

        public BackgroundJobAppService(
            IBackgroundJobRepository backgroundJobRepository,
            ILocalEventBus localEventBus,
            IBackgroundJobManager backgroundJobManager)
        {
            BackgroundJobRepository = backgroundJobRepository;
            LocalEventBus = localEventBus;
            BackgroundJobManager = backgroundJobManager;
        }


        public async Task<List<BackgroundJobRecordDto>> GetWaitingJobsAsync(int maxCount)
        {
            var list = await BackgroundJobRepository.GetWaitingListAsync(maxCount);

            return ObjectMapper.Map<List<BackgroundJobRecord>, List<BackgroundJobRecordDto>>(list);
        }


        public async Task<PagedResultDto<BackgroundJobRecordDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var count = await BackgroundJobRepository.GetCountAsync();

            var records = await BackgroundJobRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, false);

            return new PagedResultDto<BackgroundJobRecordDto>
            {
                Items = ObjectMapper.Map<List<BackgroundJobRecord>, List<BackgroundJobRecordDto>>(records),
                TotalCount = count
            };
        }
        public async Task<BackgroundJobRecordDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<BackgroundJobRecord, BackgroundJobRecordDto>(await BackgroundJobRepository.GetAsync(id));
        }
        public async Task<BackgroundJobRecordDto> UpdateAsync(Guid id, BackgroundJobUpdateDto input)
        {
            var bj = await BackgroundJobRepository.GetAsync(id);

            bj.NextTryTime = input.NextTryTime;

            await BackgroundJobRepository.UpdateAsync(bj);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<BackgroundJobRecord, BackgroundJobRecordDto>(bj);
        }

        public async Task DeleteAsync(Guid id)
        {
            await BackgroundJobRepository.DeleteAsync(id);

            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
