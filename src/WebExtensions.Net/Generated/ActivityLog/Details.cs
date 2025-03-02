using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.ActivityLog
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Details : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("data")]
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Data Data { get; set; }

        /// <summary>The name of the api call or event, or the script url if this is a content or user script event.</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }

        /// <summary>The date string when this call is triggered.</summary>
        [JsAccessPath("timeStamp")]
        [JsonPropertyName("timeStamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Date TimeStamp { get; set; }

        /// <summary>The type of log entry.  api_call is a function call made by the extension and api_event is an event callback to the extension.  content_script is logged when a content script is injected.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        public DetailsType Type { get; set; }

        /// <summary>The type of view where the activity occurred.  Content scripts will not have a viewType.</summary>
        [JsAccessPath("viewType")]
        [JsonPropertyName("viewType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ViewType? ViewType { get; set; }
    }
}
