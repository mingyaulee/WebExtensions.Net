using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

/// <summary>The new scheme for the request.</summary>
[JsonConverter(typeof(EnumStringConverter<Scheme>))]
public enum Scheme
{
    /// <summary>http</summary>
    [EnumValue("http")]
    Http,

    /// <summary>https</summary>
    [EnumValue("https")]
    Https,

    /// <summary>moz-extension</summary>
    [EnumValue("moz-extension")]
    MozExtension,
}
