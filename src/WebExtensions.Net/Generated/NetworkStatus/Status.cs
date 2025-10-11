using System.Text.Json.Serialization;

namespace WebExtensions.Net.NetworkStatus;

/// <summary>Status of the network link, if "unknown" then link is usually assumed to be "up"</summary>
[JsonConverter(typeof(EnumStringConverter<Status>))]
public enum Status
{
    /// <summary>unknown</summary>
    [EnumValue("unknown")]
    Unknown,

    /// <summary>up</summary>
    [EnumValue("up")]
    Up,

    /// <summary>down</summary>
    [EnumValue("down")]
    Down,
}
