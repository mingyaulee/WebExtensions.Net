using System.Text.Json.Serialization;

namespace WebExtensions.Net.Proxy;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<ExtraInfoSpecArrayItem>))]
public enum ExtraInfoSpecArrayItem
{
    /// <summary>requestHeaders</summary>
    [EnumValue("requestHeaders")]
    RequestHeaders,
}
