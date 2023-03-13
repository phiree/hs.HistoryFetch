using hs.HistoryFetch.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace hs.HistoryFetch;

[DependsOn(
    typeof(HistoryFetchEntityFrameworkCoreTestModule)
    )]
public class HistoryFetchDomainTestModule : AbpModule
{

}
