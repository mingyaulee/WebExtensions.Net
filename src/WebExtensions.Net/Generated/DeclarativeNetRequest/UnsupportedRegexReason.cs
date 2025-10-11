using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

/// <summary>Describes the reason why a given regular expression isn't supported.</summary>
[JsonConverter(typeof(EnumStringConverter<UnsupportedRegexReason>))]
public enum UnsupportedRegexReason
{
    /// <summary>syntaxError</summary>
    [EnumValue("syntaxError")]
    SyntaxError,

    /// <summary>memoryLimitExceeded</summary>
    [EnumValue("memoryLimitExceeded")]
    MemoryLimitExceeded,
}
