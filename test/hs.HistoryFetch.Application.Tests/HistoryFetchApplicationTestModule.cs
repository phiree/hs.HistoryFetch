using Volo.Abp.Modularity;

namespace hs.HistoryFetch;

[DependsOn(
    typeof(HistoryFetchApplicationModule),
    typeof(HistoryFetchDomainTestModule)
    )]
public class HistoryFetchApplicationTestModule : AbpModule
{

}
