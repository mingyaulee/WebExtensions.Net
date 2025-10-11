using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<OnHeadersReceivedOptions>))]
public enum OnHeadersReceivedOptions
{
    /// <summary>blocking</summary>
    [EnumValue("blocking")]
    Blocking,

    /// <summary>responseHeaders</summary>
    [EnumValue("responseHeaders")]
    ResponseHeaders,
}
