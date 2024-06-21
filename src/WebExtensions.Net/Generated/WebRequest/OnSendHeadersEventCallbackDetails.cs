using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnSendHeadersEventCallbackDetails : BaseObject
    {
        /// <summary>The cookie store ID of the contextual identity.</summary>
        [JsAccessPath("cookieStoreId")]
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId { get; set; }

        /// <summary>URL of the page into which the requested resource will be loaded.</summary>
        [JsAccessPath("documentUrl")]
        [JsonPropertyName("documentUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DocumentUrl { get; set; }

        /// <summary>The value 0 indicates that the request happens in the main frame; a positive value indicates the ID of a subframe in which the request happens. If the document of a (sub-)frame is loaded (<c>type</c> is <c>main_frame</c> or <c>sub_frame</c>), <c>frameId</c> indicates the ID of this frame, not the ID of the outer frame. Frame IDs are unique within a tab.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>True for private browsing requests.</summary>
        [JsAccessPath("incognito")]
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito { get; set; }

        /// <summary>Standard HTTP method.</summary>
        [JsAccessPath("method")]
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Method { get; set; }

        /// <summary>URL of the resource that triggered this request.</summary>
        [JsAccessPath("originUrl")]
        [JsonPropertyName("originUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OriginUrl { get; set; }

        /// <summary>ID of frame that wraps the frame which sent the request. Set to -1 if no parent frame exists.</summary>
        [JsAccessPath("parentFrameId")]
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId { get; set; }

        /// <summary>The HTTP request headers that have been sent out with this request.</summary>
        [JsAccessPath("requestHeaders")]
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpHeaders RequestHeaders { get; set; }

        /// <summary>The ID of the request. Request IDs are unique within a browser session. As a result, they could be used to relate different events of the same request.</summary>
        [JsAccessPath("requestId")]
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RequestId { get; set; }

        /// <summary>The ID of the tab in which the request takes place. Set to -1 if the request isn't related to a tab.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>Indicates if this request and its content window hierarchy is third party.</summary>
        [JsAccessPath("thirdParty")]
        [JsonPropertyName("thirdParty")]
        public bool ThirdParty { get; set; }

        /// <summary>The time when this signal is triggered, in milliseconds since the epoch.</summary>
        [JsAccessPath("timeStamp")]
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }

        /// <summary>How the requested resource will be used.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        public ResourceType Type { get; set; }

        /// <summary></summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }

        /// <summary>Tracking classification if the request has been classified.</summary>
        [JsAccessPath("urlClassification")]
        [JsonPropertyName("urlClassification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassification UrlClassification { get; set; }
    }
}
