using System.Threading.Tasks;

namespace hs.HistoryFetch.Data;

public interface IHistoryFetchDbSchemaMigrator
{
    Task MigrateAsync();
}
