using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Modularity;
using Wallee.Boc.DataPlane.Hangfire.BackgroundJobs;
using Wallee.Boc.DataPlane.Hangfire.BackgroundWorkers;

namespace Wallee.Boc.DataPlane.Hangfire
{
    [DependsOn(
        typeof(DataPlaneDomainModule),
        typeof(AbpBackgroundJobsHangfireModule),
        typeof(AbpBackgroundWorkersHangfireModule))]
    public class DataPlaneHangfireModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureHangfire(context, configuration);
        }

        private void ConfigureHangfire(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(configuration.GetConnectionString("Default"));
            });
        }

        public override async Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            await context.AddBackgroundWorkerAsync<TestWorker>();
        }
    }
}