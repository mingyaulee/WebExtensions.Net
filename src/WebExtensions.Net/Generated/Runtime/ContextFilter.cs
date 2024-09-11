using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary>A filter to match against existing extension context. Matching contexts must match all specified filters.</summary>
    [BindAllProperties]
    public partial class ContextFilter : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("contextIds")]
        [JsonPropertyName("contextIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ContextIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("contextTypes")]
        [JsonPropertyName("contextTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContextType> ContextTypes { get; set; }

        /// <summary></summary>
        [JsAccessPath("documentIds")]
        [JsonPropertyName("documentIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("documentOrigins")]
        [JsonPropertyName("documentOrigins")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentOrigins { get; set; }

        /// <summary></summary>
        [JsAccessPath("documentUrls")]
        [JsonPropertyName("documentUrls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> DocumentUrls { get; set; }

        /// <summary></summary>
        [JsAccessPath("frameIds")]
        [JsonPropertyName("frameIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> FrameIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("incognito")]
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito { get; set; }

        /// <summary></summary>
        [JsAccessPath("tabIds")]
        [JsonPropertyName("tabIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> TabIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("windowIds")]
        [JsonPropertyName("windowIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> WindowIds { get; set; }
    }
}
