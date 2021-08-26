using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnAuthRequiredEventRemoveListenerCallbackDetails : BaseObject
    {
        /// <summary>The server requesting authentication.</summary>
        [JsonPropertyName("challenger")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RemoveListenerCallbackDetailsChallenger Challenger { get; set; }

        /// <summary>The cookie store ID of the contextual identity.</summary>
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId { get; set; }

        /// <summary>URL of the page into which the requested resource will be loaded.</summary>
        [JsonPropertyName("documentUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DocumentUrl { get; set; }

        /// <summary>The value 0 indicates that the request happens in the main frame; a positive value indicates the ID of a subframe in which the request happens. If the document of a (sub-)frame is loaded (<c>type</c> is <c>main_frame</c> or <c>sub_frame</c>), <c>frameId</c> indicates the ID of this frame, not the ID of the outer frame. Frame IDs are unique within a tab.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>True for private browsing requests.</summary>
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito { get; set; }

        /// <summary>True for Proxy-Authenticate, false for WWW-Authenticate.</summary>
        [JsonPropertyName("isProxy")]
        public bool IsProxy { get; set; }

        /// <summary>Standard HTTP method.</summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Method { get; set; }

        /// <summary>URL of the resource that triggered this request.</summary>
        [JsonPropertyName("originUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OriginUrl { get; set; }

        /// <summary>ID of frame that wraps the frame which sent the request. Set to -1 if no parent frame exists.</summary>
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId { get; set; }

        /// <summary>The authentication realm provided by the server, if there is one.</summary>
        [JsonPropertyName("realm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Realm { get; set; }

        /// <summary>The ID of the request. Request IDs are unique within a browser session. As a result, they could be used to relate different events of the same request.</summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RequestId { get; set; }

        /// <summary>The HTTP response headers that were received along with this response.</summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpHeaders ResponseHeaders { get; set; }

        /// <summary>The authentication scheme, e.g. Basic or Digest.</summary>
        [JsonPropertyName("scheme")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Scheme { get; set; }

        /// <summary>Standard HTTP status code returned by the server.</summary>
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>HTTP status line of the response or the 'HTTP/0.9 200 OK' string for HTTP/0.9 responses (i.e., responses that lack a status line) or an empty string if there are no headers.</summary>
        [JsonPropertyName("statusLine")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StatusLine { get; set; }

        /// <summary>The ID of the tab in which the request takes place. Set to -1 if the request isn't related to a tab.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>Indicates if this request and its content window hierarchy is third party.</summary>
        [JsonPropertyName("thirdParty")]
        public bool ThirdParty { get; set; }

        /// <summary>The time when this signal is triggered, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }

        /// <summary>How the requested resource will be used.</summary>
        [JsonPropertyName("type")]
        public ResourceType Type { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }

        /// <summary>Tracking classification if the request has been classified.</summary>
        [JsonPropertyName("urlClassification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassification UrlClassification { get; set; }
    }
}
