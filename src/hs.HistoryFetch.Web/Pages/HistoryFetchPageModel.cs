using hs.HistoryFetch.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace hs.HistoryFetch.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HistoryFetchPageModel : AbpPageModel
{
    protected HistoryFetchPageModel()
    {
        LocalizationResourceType = typeof(HistoryFetchResource);
    }
}
