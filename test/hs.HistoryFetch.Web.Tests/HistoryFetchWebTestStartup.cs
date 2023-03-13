using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace hs.HistoryFetch;

public class HistoryFetchWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<HistoryFetchWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
