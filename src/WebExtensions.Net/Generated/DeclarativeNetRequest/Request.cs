using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary>The details of the request to test.</summary>
    [BindAllProperties]
    public partial class Request : BaseObject
    {
        /// <summary>The initiator URL (if any) for the hypothetical request.</summary>
        [JsAccessPath("initiator")]
        [JsonPropertyName("initiator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Initiator { get; set; }

        /// <summary>Standard HTTP method of the hypothetical request.</summary>
        [JsAccessPath("method")]
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Method { get; set; }

        /// <summary>The ID of the tab in which the hypothetical request takes place. Does not need to correspond to a real tab ID. Default is -1, meaning that the request isn't related to a tab.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>The resource type of the hypothetical request.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        public ResourceType Type { get; set; }

        /// <summary>The URL of the hypothetical request.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
