using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows
{
    // Type Class
    /// <summary></summary>
    public partial class CreateData : BaseObject
    {
        private bool? _allowScriptsToClose;
        private string _cookieStoreId;
        private bool? _focused;
        private int? _height;
        private bool? _incognito;
        private int? _left;
        private WindowState? _state;
        private int? _tabId;
        private string _titlePreface;
        private int? _top;
        private CreateType? _type;
        private Url _url;
        private int? _width;

        /// <summary>Allow scripts to close the window.</summary>
        [JsonPropertyName("allowScriptsToClose")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowScriptsToClose
        {
            get
            {
                InitializeProperty("allowScriptsToClose", _allowScriptsToClose);
                return _allowScriptsToClose;
            }
            set
            {
                _allowScriptsToClose = value;
            }
        }

        /// <summary>The CookieStoreId to use for all tabs that were created when the window is opened.</summary>
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

        /// <summary>If true, opens an active window. If false, opens an inactive window.</summary>
        [JsonPropertyName("focused")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Focused
        {
            get
            {
                InitializeProperty("focused", _focused);
                return _focused;
            }
            set
            {
                _focused = value;
            }
        }

        /// <summary>The height in pixels of the new window, including the frame. If not specified defaults to a natural height.</summary>
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

        /// <summary>Whether the new window should be an incognito window.</summary>
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

        /// <summary>The number of pixels to position the new window from the left edge of the screen. If not specified, the new window is offset naturally from the last focused window. This value is ignored for panels.</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Left
        {
            get
            {
                InitializeProperty("left", _left);
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        /// <summary>The initial state of the window. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined with 'left', 'top', 'width' or 'height'.</summary>
        [JsonPropertyName("state")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowState? State
        {
            get
            {
                InitializeProperty("state", _state);
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        /// <summary>The id of the tab for which you want to adopt to the new window.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId
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

        /// <summary>A string to add to the beginning of the window title.</summary>
        [JsonPropertyName("titlePreface")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string TitlePreface
        {
            get
            {
                InitializeProperty("titlePreface", _titlePreface);
                return _titlePreface;
            }
            set
            {
                _titlePreface = value;
            }
        }

        /// <summary>The number of pixels to position the new window from the top edge of the screen. If not specified, the new window is offset naturally from the last focused window. This value is ignored for panels.</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Top
        {
            get
            {
                InitializeProperty("top", _top);
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        /// <summary>Specifies what type of browser window to create. The 'panel' and 'detached_panel' types create a popup unless the '--enable-panels' flag is set.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreateType? Type
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

        /// <summary>A URL or array of URLs to open as tabs in the window. Fully-qualified URLs must include a scheme (i.e. 'http://www.google.com', not 'www.google.com'). Relative URLs will be relative to the current page within the extension. Defaults to the New Tab Page.</summary>
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

        /// <summary>The width in pixels of the new window, including the frame. If not specified defaults to a natural width.</summary>
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
    }
}
