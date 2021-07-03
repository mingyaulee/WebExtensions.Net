using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary></summary>
    public partial class OnBeforeSendHeadersEventHasListenerCallbackDetails : BaseObject
    {
        private string _cookieStoreId;
        private string _documentUrl;
        private int _frameId;
        private bool? _incognito;
        private string _method;
        private string _originUrl;
        private int _parentFrameId;
        private HttpHeaders _requestHeaders;
        private string _requestId;
        private int _tabId;
        private bool _thirdParty;
        private EpochTime _timeStamp;
        private ResourceType _type;
        private string _url;
        private UrlClassification _urlClassification;

        /// <summary>The cookie store ID of the contextual identity.</summary>
        [JsonPropertyName("cookieStoreId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CookieStoreId
        {
            get
            {
                InitializeProperty("cookieStoreId", _cookieStoreId);
                return _cookieStoreId;
            }
            set
            {
                _cookieStoreId = value;
            }
        }

        /// <summary>URL of the page into which the requested resource will be loaded.</summary>
        [JsonPropertyName("documentUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DocumentUrl
        {
            get
            {
                InitializeProperty("documentUrl", _documentUrl);
                return _documentUrl;
            }
            set
            {
                _documentUrl = value;
            }
        }

        /// <summary>The value 0 indicates that the request happens in the main frame; a positive value indicates the ID of a subframe in which the request happens. If the document of a (sub-)frame is loaded (<c>type</c> is <c>main_frame</c> or <c>sub_frame</c>), <c>frameId</c> indicates the ID of this frame, not the ID of the outer frame. Frame IDs are unique within a tab.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId
        {
            get
            {
                InitializeProperty("frameId", _frameId);
                return _frameId;
            }
            set
            {
                _frameId = value;
            }
        }

        /// <summary>True for private browsing requests.</summary>
        [JsonPropertyName("incognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Incognito
        {
            get
            {
                InitializeProperty("incognito", _incognito);
                return _incognito;
            }
            set
            {
                _incognito = value;
            }
        }

        /// <summary>Standard HTTP method.</summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Method
        {
            get
            {
                InitializeProperty("method", _method);
                return _method;
            }
            set
            {
                _method = value;
            }
        }

        /// <summary>URL of the resource that triggered this request.</summary>
        [JsonPropertyName("originUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OriginUrl
        {
            get
            {
                InitializeProperty("originUrl", _originUrl);
                return _originUrl;
            }
            set
            {
                _originUrl = value;
            }
        }

        /// <summary>ID of frame that wraps the frame which sent the request. Set to -1 if no parent frame exists.</summary>
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId
        {
            get
            {
                InitializeProperty("parentFrameId", _parentFrameId);
                return _parentFrameId;
            }
            set
            {
                _parentFrameId = value;
            }
        }

        /// <summary>The HTTP request headers that are going to be sent out with this request.</summary>
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpHeaders RequestHeaders
        {
            get
            {
                InitializeProperty("requestHeaders", _requestHeaders);
                return _requestHeaders;
            }
            set
            {
                _requestHeaders = value;
            }
        }

        /// <summary>The ID of the request. Request IDs are unique within a browser session. As a result, they could be used to relate different events of the same request.</summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RequestId
        {
            get
            {
                InitializeProperty("requestId", _requestId);
                return _requestId;
            }
            set
            {
                _requestId = value;
            }
        }

        /// <summary>The ID of the tab in which the request takes place. Set to -1 if the request isn't related to a tab.</summary>
        [JsonPropertyName("tabId")]
        public int TabId
        {
            get
            {
                InitializeProperty("tabId", _tabId);
                return _tabId;
            }
            set
            {
                _tabId = value;
            }
        }

        /// <summary>Indicates if this request and its content window hierarchy is third party.</summary>
        [JsonPropertyName("thirdParty")]
        public bool ThirdParty
        {
            get
            {
                InitializeProperty("thirdParty", _thirdParty);
                return _thirdParty;
            }
            set
            {
                _thirdParty = value;
            }
        }

        /// <summary>The time when this signal is triggered, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp
        {
            get
            {
                InitializeProperty("timeStamp", _timeStamp);
                return _timeStamp;
            }
            set
            {
                _timeStamp = value;
            }
        }

        /// <summary>How the requested resource will be used.</summary>
        [JsonPropertyName("type")]
        public ResourceType Type
        {
            get
            {
                InitializeProperty("type", _type);
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        /// <summary>Tracking classification if the request has been classified.</summary>
        [JsonPropertyName("urlClassification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UrlClassification UrlClassification
        {
            get
            {
                InitializeProperty("urlClassification", _urlClassification);
                return _urlClassification;
            }
            set
            {
                _urlClassification = value;
            }
        }
    }
}
