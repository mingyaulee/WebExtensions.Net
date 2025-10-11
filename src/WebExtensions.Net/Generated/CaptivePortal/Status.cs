using System.Text.Json.Serialization;

namespace WebExtensions.Net.CaptivePortal;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<Status>))]
public enum Status
{
    /// <summary>captive</summary>
    [EnumValue("captive")]
    Captive,

    /// <summary>clear</summary>
    [EnumValue("clear")]
    Clear,
}
