using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.GeckoProfiler
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Settings : BaseObject
    {
        /// <summary>The maximum size in bytes of the buffer used to store profiling data. A larger value allows capturing a profile that covers a greater amount of time.</summary>
        [JsAccessPath("bufferSize")]
        [JsonPropertyName("bufferSize")]
        public int BufferSize { get; set; }

        /// <summary>A list of active features for the profiler.</summary>
        [JsAccessPath("features")]
        [JsonPropertyName("features")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ProfilerFeature> Features { get; set; }

        /// <summary>Interval in milliseconds between samples of profiling data. A smaller value will increase the detail of the profiles captured.</summary>
        [JsAccessPath("interval")]
        [JsonPropertyName("interval")]
        public EpochTime Interval { get; set; }

        /// <summary>A list of thread names for which to capture profiles.</summary>
        [JsAccessPath("threads")]
        [JsonPropertyName("threads")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Threads { get; set; }

        /// <summary>The length of the window of time that's kept in the buffer. Any collected samples are discarded as soon as they are older than the number of seconds specified in this setting. Zero means no duration restriction.</summary>
        [JsAccessPath("windowLength")]
        [JsonPropertyName("windowLength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? WindowLength { get; set; }
    }
}
