using System.Text.Json.Serialization;

namespace WebExtensions.Net.Idle;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<IdleState>))]
public enum IdleState
{
    /// <summary>active</summary>
    [EnumValue("active")]
    Active,

    /// <summary>idle</summary>
    [EnumValue("idle")]
    Idle,
}
