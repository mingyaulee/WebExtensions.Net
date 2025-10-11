using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

/// <summary>The operation to be performed on a header.</summary>
[JsonConverter(typeof(EnumStringConverter<RequestHeaderOperation>))]
public enum RequestHeaderOperation
{
    /// <summary>append</summary>
    [EnumValue("append")]
    Append,

    /// <summary>set</summary>
    [EnumValue("set")]
    Set,

    /// <summary>remove</summary>
    [EnumValue("remove")]
    Remove,
}
