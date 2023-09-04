using FluentFTP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;
using Wallee.Boc.DataPlane.Background.Ftp;

namespace Wallee.Boc.DataPlane.Background
{
    [DependsOn(typeof(DataPlaneDomainModule))]
    public class DataPlaneBackgroundModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureFtp(context, configuration);

            ConfigureBackgruond();
        }


        private void ConfigureBackgruond()
        {
            //配置后台工作细节
            Configure<AbpBackgroundJobWorkerOptions>(options =>
            {
                //超时时间，设置7天(一周)，一天是86_400
                options.DefaultTimeout = 604_800;
            });
        }

        private void ConfigureFtp(ServiceConfigurationContext context, IConfiguration config)
        {
            Configure<FtpOptions>(config.GetSection("Ftp"));

            var ftpOptions = context.Services.GetRequiredService<IOptions<FtpOptions>>().Value;

            context.Services.AddTransient(typeof(IAsyncFtpClient), serviceProvider =>
            {
                return new AsyncFtpClient(ftpOptions.Address, ftpOptions.UserName, ftpOptions.Password);
            });
        }
    }
}