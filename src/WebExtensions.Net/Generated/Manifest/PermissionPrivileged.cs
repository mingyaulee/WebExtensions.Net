using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<PermissionPrivileged>))]
public enum PermissionPrivileged
{
    /// <summary>mozillaAddons</summary>
    [EnumValue("mozillaAddons")]
    MozillaAddons,

    /// <summary>activityLog</summary>
    [EnumValue("activityLog")]
    ActivityLog,

    /// <summary>networkStatus</summary>
    [EnumValue("networkStatus")]
    NetworkStatus,

    /// <summary>telemetry</summary>
    [EnumValue("telemetry")]
    Telemetry,

    /// <summary>normandyAddonStudy</summary>
    [EnumValue("normandyAddonStudy")]
    NormandyAddonStudy,
}
