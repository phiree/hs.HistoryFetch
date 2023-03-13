using hs.HistoryFetch.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace hs.HistoryFetch.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HistoryFetchController : AbpControllerBase
{
    protected HistoryFetchController()
    {
        LocalizationResource = typeof(HistoryFetchResource);
    }
}
