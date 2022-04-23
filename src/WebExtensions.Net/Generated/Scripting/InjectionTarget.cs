using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class InjectionTarget : BaseObject
    {
        /// <summary>Whether the script should inject into all frames within the tab. Defaults to false. This must not be true if <c>frameIds</c> is specified.</summary>
        [JsonPropertyName("allFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllFrames { get; set; }

        /// <summary>The IDs of specific frames to inject into.</summary>
        [JsonPropertyName("frameIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<double> FrameIds { get; set; }

        /// <summary>The ID of the tab into which to inject.</summary>
        [JsonPropertyName("tabId")]
        public double TabId { get; set; }
    }
}
