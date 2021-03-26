using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class Tab : BaseObject
    {
        
        // Property Definition
        private int? _id;
        /// <summary>
        /// The ID of the tab. Tab IDs are unique within a browser session. Under some circumstances a Tab may not be assigned an ID, for example when querying foreign tabs using the $(ref:sessions) API, in which case a session ID may be present. Tab ID can also be set to $(ref:tabs.TAB_ID_NONE) for apps and devtools windows.
        /// </summary>
        [JsonPropertyName("id")]
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
        
        // Property Definition
        private int _index;
        /// <summary>
        /// The zero-based index of the tab within its window.
        /// </summary>
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
        
        // Property Definition
        private int? _windowId;
        /// <summary>
        /// The ID of the window the tab is contained within.
        /// </summary>
        [JsonPropertyName("windowId")]
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
        
        // Property Definition
        private int? _openerTabId;
        /// <summary>
        /// The ID of the tab that opened this tab, if any. This property is only present if the opener tab still exists.
        /// </summary>
        [JsonPropertyName("openerTabId")]
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
        
        // Property Definition
        private bool _highlighted;
        /// <summary>
        /// Whether the tab is highlighted. Works as an alias of active
        /// </summary>
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
        
        // Property Definition
        private bool _active;
        /// <summary>
        /// Whether the tab is active in its window. (Does not necessarily mean the window is focused.)
        /// </summary>
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
        
        // Property Definition
        private bool _pinned;
        /// <summary>
        /// Whether the tab is pinned.
        /// </summary>
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
        
        // Property Definition
        private int? _lastAccessed;
        /// <summary>
        /// The last time the tab was accessed as the number of milliseconds since epoch.
        /// </summary>
        [JsonPropertyName("lastAccessed")]
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
        
        // Property Definition
        private bool? _audible;
        /// <summary>
        /// Whether the tab has produced sound over the past couple of seconds (but it might not be heard if also muted). Equivalent to whether the speaker audio indicator is showing.
        /// </summary>
        [JsonPropertyName("audible")]
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
        
        // Property Definition
        private MutedInfo _mutedInfo;
        /// <summary>
        /// Current tab muted state and the reason for the last state change.
        /// </summary>
        [JsonPropertyName("mutedInfo")]
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
        
        // Property Definition
        private string _url;
        /// <summary>
        /// The URL the tab is displaying. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.
        /// </summary>
        [JsonPropertyName("url")]
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
        
        // Property Definition
        private string _title;
        /// <summary>
        /// The title of the tab. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission.
        /// </summary>
        [JsonPropertyName("title")]
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
        
        // Property Definition
        private string _favIconUrl;
        /// <summary>
        /// The URL of the tab's favicon. This property is only present if the extension's manifest includes the <c>"tabs"</c> permission. It may also be an empty string if the tab is loading.
        /// </summary>
        [JsonPropertyName("favIconUrl")]
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
        
        // Property Definition
        private string _status;
        /// <summary>
        /// Either <em>loading</em> or <em>complete</em>.
        /// </summary>
        [JsonPropertyName("status")]
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
        
        // Property Definition
        private bool? _discarded;
        /// <summary>
        /// True while the tab is not loaded with content.
        /// </summary>
        [JsonPropertyName("discarded")]
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
        
        // Property Definition
        private bool _incognito;
        /// <summary>
        /// Whether the tab is in an incognito window.
        /// </summary>
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
        
        // Property Definition
        private int? _width;
        /// <summary>
        /// The width of the tab in pixels.
        /// </summary>
        [JsonPropertyName("width")]
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
        
        // Property Definition
        private int? _height;
        /// <summary>
        /// The height of the tab in pixels.
        /// </summary>
        [JsonPropertyName("height")]
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
        
        // Property Definition
        private bool? _hidden;
        /// <summary>
        /// True if the tab is hidden.
        /// </summary>
        [JsonPropertyName("hidden")]
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
        
        // Property Definition
        private string _sessionId;
        /// <summary>
        /// The session ID used to uniquely identify a Tab obtained from the $(ref:sessions) API.
        /// </summary>
        [JsonPropertyName("sessionId")]
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
        
        // Property Definition
        private string _cookieStoreId;
        /// <summary>
        /// The CookieStoreId used for the tab.
        /// </summary>
        [JsonPropertyName("cookieStoreId")]
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
        
        // Property Definition
        private bool? _isArticle;
        /// <summary>
        /// Whether the document in the tab can be rendered in reader mode.
        /// </summary>
        [JsonPropertyName("isArticle")]
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
        
        // Property Definition
        private bool? _isInReaderMode;
        /// <summary>
        /// Whether the document in the tab is being rendered in reader mode.
        /// </summary>
        [JsonPropertyName("isInReaderMode")]
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
        
        // Property Definition
        private SharingState _sharingState;
        /// <summary>
        /// Current tab sharing state for screen, microphone and camera.
        /// </summary>
        [JsonPropertyName("sharingState")]
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
        
        // Property Definition
        private bool? _attention;
        /// <summary>
        /// Whether the tab is drawing attention.
        /// </summary>
        [JsonPropertyName("attention")]
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
        
        // Property Definition
        private int? _successorTabId;
        /// <summary>
        /// The ID of this tab's successor, if any; $(ref:tabs.TAB_ID_NONE) otherwise.
        /// </summary>
        [JsonPropertyName("successorTabId")]
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
    }
}

