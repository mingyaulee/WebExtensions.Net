using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<OptionalPermissionType2>))]
    public enum OptionalPermissionType2
    {
        /// <summary>clipboardRead</summary>
        [EnumValue("clipboardRead")]
        ClipboardRead,

        /// <summary>clipboardWrite</summary>
        [EnumValue("clipboardWrite")]
        ClipboardWrite,

        /// <summary>geolocation</summary>
        [EnumValue("geolocation")]
        Geolocation,

        /// <summary>notifications</summary>
        [EnumValue("notifications")]
        Notifications,

        /// <summary>browserSettings</summary>
        [EnumValue("browserSettings")]
        BrowserSettings,

        /// <summary>declarativeNetRequestFeedback</summary>
        [EnumValue("declarativeNetRequestFeedback")]
        DeclarativeNetRequestFeedback,

        /// <summary>downloads</summary>
        [EnumValue("downloads")]
        Downloads,

        /// <summary>downloads.open</summary>
        [EnumValue("downloads.open")]
        DownloadsOpen,

        /// <summary>management</summary>
        [EnumValue("management")]
        Management,

        /// <summary>privacy</summary>
        [EnumValue("privacy")]
        Privacy,

        /// <summary>proxy</summary>
        [EnumValue("proxy")]
        Proxy,

        /// <summary>nativeMessaging</summary>
        [EnumValue("nativeMessaging")]
        NativeMessaging,

        /// <summary>webNavigation</summary>
        [EnumValue("webNavigation")]
        WebNavigation,

        /// <summary>bookmarks</summary>
        [EnumValue("bookmarks")]
        Bookmarks,

        /// <summary>browsingData</summary>
        [EnumValue("browsingData")]
        BrowsingData,

        /// <summary>devtools</summary>
        [EnumValue("devtools")]
        Devtools,

        /// <summary>find</summary>
        [EnumValue("find")]
        Find,

        /// <summary>history</summary>
        [EnumValue("history")]
        History,

        /// <summary>pkcs11</summary>
        [EnumValue("pkcs11")]
        Pkcs11,

        /// <summary>sessions</summary>
        [EnumValue("sessions")]
        Sessions,

        /// <summary>tabs</summary>
        [EnumValue("tabs")]
        Tabs,

        /// <summary>tabHide</summary>
        [EnumValue("tabHide")]
        TabHide,

        /// <summary>topSites</summary>
        [EnumValue("topSites")]
        TopSites,
    }
}
