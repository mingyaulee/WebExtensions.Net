using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<OptionalPermissionNoPrompt>))]
public enum OptionalPermissionNoPrompt
{
    /// <summary>idle</summary>
    [EnumValue("idle")]
    Idle,

    /// <summary>cookies</summary>
    [EnumValue("cookies")]
    Cookies,

    /// <summary>scripting</summary>
    [EnumValue("scripting")]
    Scripting,

    /// <summary>webRequest</summary>
    [EnumValue("webRequest")]
    WebRequest,

    /// <summary>webRequestAuthProvider</summary>
    [EnumValue("webRequestAuthProvider")]
    WebRequestAuthProvider,

    /// <summary>webRequestBlocking</summary>
    [EnumValue("webRequestBlocking")]
    WebRequestBlocking,

    /// <summary>webRequestFilterResponse</summary>
    [EnumValue("webRequestFilterResponse")]
    WebRequestFilterResponse,

    /// <summary>webRequestFilterResponse.serviceWorkerScript</summary>
    [EnumValue("webRequestFilterResponse.serviceWorkerScript")]
    WebRequestFilterResponseServiceWorkerScript,

    /// <summary>menus.overrideContext</summary>
    [EnumValue("menus.overrideContext")]
    MenusOverrideContext,

    /// <summary>search</summary>
    [EnumValue("search")]
    Search,

    /// <summary>tabGroups</summary>
    [EnumValue("tabGroups")]
    TabGroups,

    /// <summary>activeTab</summary>
    [EnumValue("activeTab")]
    ActiveTab,
}
