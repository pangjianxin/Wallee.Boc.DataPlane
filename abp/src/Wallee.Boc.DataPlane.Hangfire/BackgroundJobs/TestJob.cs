using Hangfire;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundJobs
{
    [Queue("default")]
    public class TestJob : AsyncBackgroundJob<TestJobArgs>, ITransientDependency
    {
        // HangfireBackgroundJobManager

        public override async Task ExecuteAsync(TestJobArgs args)
        {
            Logger.LogInformation("TestJob Executing.....");
            await Task.Delay(100);
            //throw new ArgumentException(nameof(TestJobArgs));
        }
    }
}
