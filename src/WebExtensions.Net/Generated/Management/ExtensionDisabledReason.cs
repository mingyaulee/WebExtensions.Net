using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management;

/// <summary>A reason the item is disabled.</summary>
[JsonConverter(typeof(EnumStringConverter<ExtensionDisabledReason>))]
public enum ExtensionDisabledReason
{
    /// <summary>unknown</summary>
    [EnumValue("unknown")]
    Unknown,

    /// <summary>permissions_increase</summary>
    [EnumValue("permissions_increase")]
    PermissionsIncrease,
}
