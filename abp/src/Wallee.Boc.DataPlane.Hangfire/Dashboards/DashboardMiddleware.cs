using Hangfire;
using Hangfire.Common;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.BackgroundWorkers.Hangfire;

namespace Wallee.Boc.DataPlane.Hangfire.Dashboards
{
    public static class DashboardMiddleware
    {
        public static void UseMyHangfireDashboard(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetRequiredService<IOptions<AbpBackgroundJobOptions>>().Value;
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                DashboardTitle = "....",
                DisplayNameFunc = (DashboardContext dashboardContext, Job job) =>
                {
                    var jobType = job.Type;

                    string jobName = default!;

                    if (jobType.IsGenericType && jobType.GetGenericTypeDefinition() == typeof(HangfireJobExecutionAdapter<>))
                    {
                        var argType = jobType.GetGenericArguments()[0];
                        jobName = options.GetJob(argType).JobName;
                    }
                    else if (typeof(HangfireBackgroundWorkerBase).IsAssignableFrom(jobType))
                    {
                        var filters = job.Method.GetCustomAttribute<JobDisplayNameAttribute>();
                        jobName = filters?.DisplayName!;
                    }
                    return jobName;
                }
            });
        }
    }
}
