using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    /// <summary>The performance warning event severity. Will be 'high' for serious and user-visible issues.</summary>
    [JsonConverter(typeof(EnumStringConverter<OnPerformanceWarningSeverity>))]
    public enum OnPerformanceWarningSeverity
    {
        /// <summary>low</summary>
        [EnumValue("low")]
        Low,

        /// <summary>medium</summary>
        [EnumValue("medium")]
        Medium,

        /// <summary>high</summary>
        [EnumValue("high")]
        High,
    }
}
