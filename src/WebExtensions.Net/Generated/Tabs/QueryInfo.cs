using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class QueryInfo : BaseObject
    {
        private bool? _active;
        private bool? _attention;
        private bool? _audible;
        private bool? _camera;
        private string _cookieStoreId;
        private bool? _currentWindow;
        private bool? _discarded;
        private bool? _hidden;
        private bool? _highlighted;
        private int? _index;
        private bool? _lastFocusedWindow;
        private bool? _microphone;
        private bool? _muted;
        private int? _openerTabId;
        private bool? _pinned;
        private Screen _screen;
        private TabStatus? _status;
        private string _title;
        private Url _url;
        private int? _windowId;
        private WindowType? _windowType;

        /// <summary>Whether the tabs are active in their windows.</summary>
        [JsonPropertyName("active")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Active
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

        /// <summary>Whether the tabs are drawing attention.</summary>
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

        /// <summary>Whether the tabs are audible.</summary>
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

        /// <summary>True if the tab is using the camera.</summary>
        [JsonPropertyName("camera")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Camera
        {
            get
            {
                InitializeProperty("camera", _camera);
                return _camera;
            }
            set
            {
                _camera = value;
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

        /// <summary>Whether the tabs are in the $(topic:current-window)[current window].</summary>
        [JsonPropertyName("currentWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CurrentWindow
        {
            get
            {
                InitializeProperty("currentWindow", _currentWindow);
                return _currentWindow;
            }
            set
            {
                _currentWindow = value;
            }
        }

        /// <summary>True while the tabs are not loaded with content.</summary>
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

        /// <summary>True while the tabs are hidden.</summary>
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

        /// <summary>Whether the tabs are highlighted.  Works as an alias of active.</summary>
        [JsonPropertyName("highlighted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Highlighted
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

        /// <summary>The position of the tabs within their windows.</summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index
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

        /// <summary>Whether the tabs are in the last focused window.</summary>
        [JsonPropertyName("lastFocusedWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LastFocusedWindow
        {
            get
            {
                InitializeProperty("lastFocusedWindow", _lastFocusedWindow);
                return _lastFocusedWindow;
            }
            set
            {
                _lastFocusedWindow = value;
            }
        }

        /// <summary>True if the tab is using the microphone.</summary>
        [JsonPropertyName("microphone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Microphone
        {
            get
            {
                InitializeProperty("microphone", _microphone);
                return _microphone;
            }
            set
            {
                _microphone = value;
            }
        }

        /// <summary>Whether the tabs are muted.</summary>
        [JsonPropertyName("muted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Muted
        {
            get
            {
                InitializeProperty("muted", _muted);
                return _muted;
            }
            set
            {
                _muted = value;
            }
        }

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
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

        /// <summary>Whether the tabs are pinned.</summary>
        [JsonPropertyName("pinned")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Pinned
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

        /// <summary>True for any screen sharing, or a string to specify type of screen sharing.</summary>
        [JsonPropertyName("screen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Screen Screen
        {
            get
            {
                InitializeProperty("screen", _screen);
                return _screen;
            }
            set
            {
                _screen = value;
            }
        }

        /// <summary>Whether the tabs have completed loading.</summary>
        [JsonPropertyName("status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TabStatus? Status
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

        /// <summary>Match page titles against a pattern.</summary>
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

        /// <summary>Match tabs against one or more $(topic:match_patterns)[URL patterns]. Note that fragment identifiers are not matched.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Url Url
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

        /// <summary>The ID of the parent window, or $(ref:windows.WINDOW_ID_CURRENT) for the $(topic:current-window)[current window].</summary>
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

        /// <summary>The type of window the tabs are in.</summary>
        [JsonPropertyName("windowType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowType? WindowType
        {
            get
            {
                InitializeProperty("windowType", _windowType);
                return _windowType;
            }
            set
            {
                _windowType = value;
            }
        }
    }
}
