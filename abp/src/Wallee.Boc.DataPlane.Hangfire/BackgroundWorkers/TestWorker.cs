using Hangfire;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundWorkers
{
    public class TestWorker : HangfireBackgroundWorkerBase
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TestWorker(IBackgroundJobManager backgroundJobManager)
        {
            RecurringJobId = "TestWorker";
            CronExpression = Cron.Daily();
            _backgroundJobManager = backgroundJobManager;
        }
        [JobDisplayName("Test Worker")]
        public override async Task DoWorkAsync(CancellationToken cancellationToken = default)
        {
            await _backgroundJobManager.EnqueueAsync(new FirstJobArgs()
            {
                Date = DateTime.Now,
                Continuation = new SecondJobArgs()
                {
                    Date = DateTime.Now,
                    Continuation = new ThirdJobArgs()
                    {
                        Date = DateTime.Now,
                        Continuation = new FirstJobArgs
                        {
                            Date = DateTime.Now.AddDays(1)
                        }
                    }
                }
            });
        }
    }
}
