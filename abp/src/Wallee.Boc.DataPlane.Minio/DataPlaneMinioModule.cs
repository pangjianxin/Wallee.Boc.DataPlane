using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Minio;
using Volo.Abp.Modularity;

namespace Wallee.Boc.DataPlane.Minio
{
    [DependsOn(
        typeof(DataPlaneDomainModule),
        typeof(AbpBlobStoringMinioModule)
        )]
    public class DataPlaneMinioModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var config = context.Services.GetConfiguration();
            ConfigureMinio(config);
        }

        private void ConfigureMinio(IConfiguration configuration)
        {
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureDefault(config =>
                {
                    config.UseMinio(option =>
                    {
                        option.EndPoint = configuration["Blob:Minio:EndPoint"];
                        option.AccessKey = configuration["Blob:Minio:AccessKey"];
                        option.SecretKey = configuration["Blob:Minio:SecretKey"];
                        option.CreateBucketIfNotExists = true;
                    });
                });
            });
        }
    }
}