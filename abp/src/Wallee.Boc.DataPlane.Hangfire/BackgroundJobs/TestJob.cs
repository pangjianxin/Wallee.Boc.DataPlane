using Hangfire;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Wallee.Boc.DataPlane.BackgroundJobs;
using Wallee.Boc.DataPlane.Hangfire.Common;

namespace Wallee.Boc.DataPlane.Hangfire.BackgroundJobs
{
    [Queue("default")]
    public class FirstJob : AsyncContinuouslyBackgroundJob<FirstJobArgs, SecondJobArgs>, ITransientDependency
    {
        public FirstJob(IBackgroundJobManager backgroundJobManager) : base(backgroundJobManager)
        {
            Delay = TimeSpan.FromSeconds(10);
        }
        public override async Task ExecuteRawAsync(FirstJobArgs args)
        {
            Logger.LogInformation($"-----------------------{args.Date:yyyy MM dd}--------------first job executing......");
            await Task.Delay(500);
        }
    }

    [Queue("default")]
    public class SecondJob : AsyncContinuouslyBackgroundJob<SecondJobArgs, ThirdJobArgs>, ITransientDependency
    {
        public SecondJob(IBackgroundJobManager backgroundJobManager) : base(backgroundJobManager)
        {
            Delay = TimeSpan.FromSeconds(10);
        }
        public override async Task ExecuteRawAsync(SecondJobArgs args)
        {
            Logger.LogInformation($"-----------------------------{args.Date:yyyy MM dd}--------second job executing......");
            await Task.Delay(500);
        }
    }

    [Queue("default")]
    public class ThirdJob : AsyncContinuouslyBackgroundJob<ThirdJobArgs, FirstJobArgs>, ITransientDependency
    {
        public ThirdJob(IBackgroundJobManager backgroundJobManager) : base(backgroundJobManager)
        {
            Delay = TimeSpan.FromSeconds(10);
        }
        public override async Task ExecuteRawAsync(ThirdJobArgs args)
        {
            Logger.LogInformation($"----------------------------{args.Date:yyyy MM dd}---------third job executing......");
            await Task.Delay(500);
        }
    }
}
