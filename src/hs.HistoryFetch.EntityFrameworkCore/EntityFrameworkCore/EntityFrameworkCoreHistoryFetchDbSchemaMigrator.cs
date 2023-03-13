using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using hs.HistoryFetch.Data;
using Volo.Abp.DependencyInjection;

namespace hs.HistoryFetch.EntityFrameworkCore;

public class EntityFrameworkCoreHistoryFetchDbSchemaMigrator
    : IHistoryFetchDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHistoryFetchDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HistoryFetchDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HistoryFetchDbContext>()
            .Database
            .MigrateAsync();
    }
}
