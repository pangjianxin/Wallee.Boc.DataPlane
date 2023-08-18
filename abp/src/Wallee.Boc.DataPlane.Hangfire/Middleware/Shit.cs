using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Hangfire.Middleware
{
    public static class Shit
    {
        public static void UseHangfireWithAuth(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            var backgroundJobOptions =
              serviceProvider.GetRequiredService<IOptions<AbpBackgroundJobOptions>>().Value;
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                DashboardTitle = "Fucnk",
                DisplayNameFunc = (jobContext, job) =>
                {
                    var jobType = job.Args.First().GetType();
                    var abpJobType = backgroundJobOptions.GetJob(jobType);
                    return abpJobType.JobName;
                }
            });
        }
    }
}
