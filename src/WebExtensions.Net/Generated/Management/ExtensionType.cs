using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management;

/// <summary>The type of this extension, 'extension' or 'theme'.</summary>
[JsonConverter(typeof(EnumStringConverter<ExtensionType>))]
public enum ExtensionType
{
    /// <summary>extension</summary>
    [EnumValue("extension")]
    Extension,

    /// <summary>theme</summary>
    [EnumValue("theme")]
    Theme,

    /// <summary>hosted_app</summary>
    [EnumValue("hosted_app")]
    HostedApp,

    /// <summary>packaged_app</summary>
    [EnumValue("packaged_app")]
    PackagedApp,

    /// <summary>legacy_packaged_app</summary>
    [EnumValue("legacy_packaged_app")]
    LegacyPackagedApp,

    /// <summary>login_screen_extension</summary>
    [EnumValue("login_screen_extension")]
    LoginScreenExtension,
}
