using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace hs.HistoryFetch.Web;

[Dependency(ReplaceServices = true)]
public class HistoryFetchBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HistoryFetch";
}
