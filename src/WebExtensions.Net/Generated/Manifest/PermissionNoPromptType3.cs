using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<PermissionNoPromptType3>))]
    public enum PermissionNoPromptType3
    {
        /// <summary>alarms</summary>
        [EnumValue("alarms")]
        Alarms,

        /// <summary>storage</summary>
        [EnumValue("storage")]
        Storage,

        /// <summary>unlimitedStorage</summary>
        [EnumValue("unlimitedStorage")]
        UnlimitedStorage,

        /// <summary>declarativeNetRequestWithHostAccess</summary>
        [EnumValue("declarativeNetRequestWithHostAccess")]
        DeclarativeNetRequestWithHostAccess,

        /// <summary>dns</summary>
        [EnumValue("dns")]
        Dns,

        /// <summary>theme</summary>
        [EnumValue("theme")]
        Theme,

        /// <summary>captivePortal</summary>
        [EnumValue("captivePortal")]
        CaptivePortal,

        /// <summary>contextualIdentities</summary>
        [EnumValue("contextualIdentities")]
        ContextualIdentities,

        /// <summary>identity</summary>
        [EnumValue("identity")]
        Identity,

        /// <summary>menus</summary>
        [EnumValue("menus")]
        Menus,

        /// <summary>contextMenus</summary>
        [EnumValue("contextMenus")]
        ContextMenus,

        /// <summary>geckoProfiler</summary>
        [EnumValue("geckoProfiler")]
        GeckoProfiler,
    }
}
