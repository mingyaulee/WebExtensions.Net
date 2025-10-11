using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<MatchPatternType1>))]
public enum MatchPatternType1
{
    /// <summary>'all_urls'</summary>
    [EnumValue("<all_urls>")]
    AllUrls,
}
