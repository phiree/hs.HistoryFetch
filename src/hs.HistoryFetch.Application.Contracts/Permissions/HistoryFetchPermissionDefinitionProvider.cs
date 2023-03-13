using hs.HistoryFetch.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace hs.HistoryFetch.Permissions;

public class HistoryFetchPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HistoryFetchPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HistoryFetchPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HistoryFetchResource>(name);
    }
}
