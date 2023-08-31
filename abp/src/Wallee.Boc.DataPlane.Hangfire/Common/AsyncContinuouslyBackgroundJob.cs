using Hangfire;
using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.Common
{
    public abstract class AsyncContinuouslyBackgroundJob<TArgs, TNext> : AsyncBackgroundJob<TArgs> where TArgs : BackgroundJobArgsWithContinuation<TNext>
    {
        protected IBackgroundJobManager BackgroundJobManager { get; set; }
        private DateTime ReportDate { get; set; }

        public AsyncContinuouslyBackgroundJob(IBackgroundJobManager backgroundJobManager)
        {
            BackgroundJobManager = backgroundJobManager;
            Delay = TimeSpan.FromSeconds(5);
            Cron.Daily(6, 10);

        }
        protected TimeSpan Delay { get; set; }
        public override async Task ExecuteAsync(TArgs args)
        {
            await ExecuteRawAsync(args);

            await ContinueWithAsync(args.Continuation);
        }

        public abstract Task ExecuteRawAsync(TArgs args);
        protected async Task ContinueWithAsync(TNext args)
        {
            await BackgroundJobManager.EnqueueAsync(args, delay: Delay);
        }
    }
}
