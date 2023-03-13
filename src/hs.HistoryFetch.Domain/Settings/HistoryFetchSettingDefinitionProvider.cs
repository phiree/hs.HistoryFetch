using Volo.Abp.Settings;

namespace hs.HistoryFetch.Settings;

public class HistoryFetchSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HistoryFetchSettings.MySetting1));
    }
}
