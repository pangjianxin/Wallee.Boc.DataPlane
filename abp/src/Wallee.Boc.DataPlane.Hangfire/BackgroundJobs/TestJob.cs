using Hangfire;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundJobs
{
    public class TestJob : AsyncBackgroundJob<TestJobArgs>
    {
        private readonly ILogger<TestJob> _logger;

        public TestJob(ILogger<TestJob> logger)
        {
            _logger = logger;
        }

        [AutomaticRetry(Attempts = 100)]
        [Queue("default")]
        public override Task ExecuteAsync(TestJobArgs args)
        {
            _logger.LogInformation("TestJob Executing.....");

            throw new NotImplementedException();
        }
    }
}
