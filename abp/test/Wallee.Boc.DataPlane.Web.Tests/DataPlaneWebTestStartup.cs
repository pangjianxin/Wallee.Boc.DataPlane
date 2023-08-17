using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Wallee.Boc.DataPlane;

public class DataPlaneWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<DataPlaneWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
