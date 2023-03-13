using System;
using System.Collections.Generic;
using System.Text;
using hs.HistoryFetch.Localization;
using Volo.Abp.Application.Services;

namespace hs.HistoryFetch;

/* Inherit your application services from this class.
 */
public abstract class HistoryFetchAppService : ApplicationService
{
    protected HistoryFetchAppService()
    {
        LocalizationResource = typeof(HistoryFetchResource);
    }
}
