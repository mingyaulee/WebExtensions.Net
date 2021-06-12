using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class Tab : BaseObject
    {
        private bool _active;
        private bool? _attention;
        private bool? _audible;
        private string _cookieStoreId;
        private bool? _discarded;
        private string _favIconUrl;
        private int? _height;
        private bool? _hidden;
        private bool _highlighted;
        private int? _id;
        private bool _incognito;
        private int _index;
        private bool? _isArticle;
        private bool? _isInReaderMode;
        private int? _lastAccessed;
        private MutedInfo _mutedInfo;
        private int? _openerTabId;
        private bool _pinned;
        private string _sessionId;
        private SharingState _sharingState;
        private string _status;
        private int? _successorTabId;
        private string _title;
        private string _url;
        private int? _width;
        private int? _windowId;

        /// <summary>Whether the tab is active in its window. (Does not necessarily mean the window is focused.)</summary>
        [JsonPropertyName("active")]
        public bool Active
        {
            get
            {
                InitializeProperty("active", _active);
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        /// <summary>Whether the tab is drawing attention.</summary>
        [JsonPropertyName("attention")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Attention
        {
            get
            {
                InitializeProperty("attention", _attention);
                return _attention;
            }
            set
            {
                _attention = value;
            }
        }

        /// <summary>Whether the tab has produced sound over the past couple of seconds (but it might not be heard if also muted). Equivalent to whether the speaker audio indicator is showing.</summary>
        [JsonPropertyName("audible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Audible
        {
            get
            {
                InitializeProperty("audible", _audible);
                return _audible;
            }
            set
            {
                _audible = value;
            }
        }

        /// <summary>The CookieStoreId used for the tab.</summary>
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

        /// <summary>True while the tab is not loaded with content.</summary>
        [JsonPropertyName("discarded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Discarded
        {
            get
            {
                InitializeProperty("discarded", _discarded);
                return _discarded;
            }
            set
            {
                _discarded = value;
            }
        }

        /// <summary>The URL of the tab's favicon. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission. It may also be an empty string if the tab is loading.</summary>
        [JsonPropertyName("favIconUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FavIconUrl
        {
            get
            {
                InitializeProperty("favIconUrl", _favIconUrl);
                return _favIconUrl;
            }
            set
            {
                _favIconUrl = value;
            }
        }

        /// <summary>The height of the tab in pixels.</summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height
        {
            get
            {
                InitializeProperty("height", _height);
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary>True if the tab is hidden.</summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hidden
        {
            get
            {
                InitializeProperty("hidden", _hidden);
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }

        /// <summary>Whether the tab is highlighted. Works as an alias of active</summary>
        [JsonPropertyName("highlighted")]
        public bool Highlighted
        {
            get
            {
                InitializeProperty("highlighted", _highlighted);
                return _highlighted;
            }
            set
            {
                _highlighted = value;
            }
        }

        /// <summary>The ID of the tab. Tab IDs are unique within a browser session. Under some circumstances a Tab may not be assigned an ID, for example when querying foreign tabs using the $(ref:sessions) API, in which case a session ID may be present. Tab ID can also be set to $(ref:tabs.TAB_ID_NONE) for apps and devtools windows.</summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>Whether the tab is in an incognito window.</summary>
        [JsonPropertyName("incognito")]
        public bool Incognito
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

        /// <summary>The zero-based index of the tab within its window.</summary>
        [JsonPropertyName("index")]
        public int Index
        {
            get
            {
                InitializeProperty("index", _index);
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        /// <summary>Whether the document in the tab can be rendered in reader mode.</summary>
        [JsonPropertyName("isArticle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsArticle
        {
            get
            {
                InitializeProperty("isArticle", _isArticle);
                return _isArticle;
            }
            set
            {
                _isArticle = value;
            }
        }

        /// <summary>Whether the document in the tab is being rendered in reader mode.</summary>
        [JsonPropertyName("isInReaderMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsInReaderMode
        {
            get
            {
                InitializeProperty("isInReaderMode", _isInReaderMode);
                return _isInReaderMode;
            }
            set
            {
                _isInReaderMode = value;
            }
        }

        /// <summary>The last time the tab was accessed as the number of milliseconds since epoch.</summary>
        [JsonPropertyName("lastAccessed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? LastAccessed
        {
            get
            {
                InitializeProperty("lastAccessed", _lastAccessed);
                return _lastAccessed;
            }
            set
            {
                _lastAccessed = value;
            }
        }

        /// <summary>Current tab muted state and the reason for the last state change.</summary>
        [JsonPropertyName("mutedInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MutedInfo MutedInfo
        {
            get
            {
                InitializeProperty("mutedInfo", _mutedInfo);
                return _mutedInfo;
            }
            set
            {
                _mutedInfo = value;
            }
        }

        /// <summary>The ID of the tab that opened this tab, if any. This property is only present if the opener tab still exists.</summary>
        [JsonPropertyName("openerTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OpenerTabId
        {
            get
            {
                InitializeProperty("openerTabId", _openerTabId);
                return _openerTabId;
            }
            set
            {
                _openerTabId = value;
            }
        }

        /// <summary>Whether the tab is pinned.</summary>
        [JsonPropertyName("pinned")]
        public bool Pinned
        {
            get
            {
                InitializeProperty("pinned", _pinned);
                return _pinned;
            }
            set
            {
                _pinned = value;
            }
        }

        /// <summary>The session ID used to uniquely identify a Tab obtained from the $(ref:sessions) API.</summary>
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SessionId
        {
            get
            {
                InitializeProperty("sessionId", _sessionId);
                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }

        /// <summary>Current tab sharing state for screen, microphone and camera.</summary>
        [JsonPropertyName("sharingState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SharingState SharingState
        {
            get
            {
                InitializeProperty("sharingState", _sharingState);
                return _sharingState;
            }
            set
            {
                _sharingState = value;
            }
        }

        /// <summary>Either <em>loading</em> or <em>complete</em>.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status
        {
            get
            {
                InitializeProperty("status", _status);
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        /// <summary>The ID of this tab's successor, if any; $(ref:tabs.TAB_ID_NONE) otherwise.</summary>
        [JsonPropertyName("successorTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SuccessorTabId
        {
            get
            {
                InitializeProperty("successorTabId", _successorTabId);
                return _successorTabId;
            }
            set
            {
                _successorTabId = value;
            }
        }

        /// <summary>The title of the tab. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title
        {
            get
            {
                InitializeProperty("title", _title);
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>The URL the tab is displaying. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.</summary>
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

        /// <summary>The width of the tab in pixels.</summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width
        {
            get
            {
                InitializeProperty("width", _width);
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>The ID of the window the tab is contained within.</summary>
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId
        {
            get
            {
                InitializeProperty("windowId", _windowId);
                return _windowId;
            }
            set
            {
                _windowId = value;
            }
        }
    }
}
