using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    /// <summary>The performance warning event category, e.g. 'content_script'.</summary>
    [JsonConverter(typeof(EnumStringConverter<OnPerformanceWarningCategory>))]
    public enum OnPerformanceWarningCategory
    {
        /// <summary>content_script</summary>
        [EnumValue("content_script")]
        ContentScript,
    }
}
