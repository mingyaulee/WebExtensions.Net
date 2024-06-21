using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddUrlDetails : BaseObject
    {
        /// <summary>The title of the page.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The $(topic:transition-types)[transition type] for this visit from its referrer.</summary>
        [JsAccessPath("transition")]
        [JsonPropertyName("transition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TransitionType? Transition { get; set; }

        /// <summary>The URL to add. Must be a valid URL that can be added to history.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }

        /// <summary>The date when this visit occurred.</summary>
        [JsAccessPath("visitTime")]
        [JsonPropertyName("visitTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date VisitTime { get; set; }
    }
}
