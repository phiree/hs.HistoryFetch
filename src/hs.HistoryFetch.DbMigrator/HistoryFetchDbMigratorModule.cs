using hs.HistoryFetch.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace hs.HistoryFetch.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HistoryFetchEntityFrameworkCoreModule),
    typeof(HistoryFetchApplicationContractsModule)
    )]
public class HistoryFetchDbMigratorModule : AbpModule
{

}
