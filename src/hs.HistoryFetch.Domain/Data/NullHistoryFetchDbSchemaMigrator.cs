using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace hs.HistoryFetch.Data;

/* This is used if database provider does't define
 * IHistoryFetchDbSchemaMigrator implementation.
 */
public class NullHistoryFetchDbSchemaMigrator : IHistoryFetchDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
