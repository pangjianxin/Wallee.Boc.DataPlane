using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundJobs
{

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
