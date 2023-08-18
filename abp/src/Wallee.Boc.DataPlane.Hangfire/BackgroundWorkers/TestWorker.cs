using Hangfire;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Wallee.Boc.DataPlane.Hangfire.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundWorkers
{
    public class TestWorker : HangfireBackgroundWorkerBase
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TestWorker(IBackgroundJobManager backgroundJobManager)
        {
            RecurringJobId = "后台工作者测试";
            CronExpression = Cron.MinuteInterval(1);
            _backgroundJobManager = backgroundJobManager;
        }
        public override async Task DoWorkAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"--------------------test worker start to trigger the background job----------------------");
            await _backgroundJobManager.EnqueueAsync(new TestJobArgs(), delay: TimeSpan.FromSeconds(4));
        }
    }
}
