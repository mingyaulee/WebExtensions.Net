using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>An object describing filters to apply to webRequest events.</summary>
    [BindAllProperties]
    public partial class RequestFilter : BaseObject
    {
        /// <summary>If provided, requests that do not match the incognito state will be filtered out.</summary>
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito { get; set; }

        /// <summary></summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>A list of request types. Requests that cannot match any of the types will be filtered out.</summary>
        [JsonPropertyName("types")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ResourceType> Types { get; set; }

        /// <summary>A list of URLs or URL patterns. Requests that cannot match any of the URLs will be filtered out.</summary>
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Urls { get; set; }

        /// <summary></summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
