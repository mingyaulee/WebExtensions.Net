using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class CreateProperties : BaseObject
    {
        private bool? _active;
        private string _cookieStoreId;
        private bool? _discarded;
        private int? _index;
        private int? _openerTabId;
        private bool? _openInReaderMode;
        private bool? _pinned;
        private string _title;
        private string _url;
        private int? _windowId;

        /// <summary>Whether the tab should become the active tab in the window. Does not affect whether the window is focused (see $(ref:windows.update)). Defaults to <c>true</c>.</summary>
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

        /// <summary>The CookieStoreId for the tab that opened this tab.</summary>
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

        /// <summary>Whether the tab is marked as 'discarded' when created.</summary>
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

        /// <summary>The position the tab should take in the window. The provided value will be clamped to between zero and the number of tabs in the window.</summary>
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

        /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as the newly created tab.</summary>
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

        /// <summary>Whether the document in the tab should be opened in reader mode.</summary>
        [JsonPropertyName("openInReaderMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OpenInReaderMode
        {
            get
            {
                InitializeProperty("openInReaderMode", _openInReaderMode);
                return _openInReaderMode;
            }
            set
            {
                _openInReaderMode = value;
            }
        }

        /// <summary>Whether the tab should be pinned. Defaults to <c>false</c></summary>
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

        /// <summary>The title used for display if the tab is created in discarded mode.</summary>
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

        /// <summary>The URL to navigate the tab to initially. Fully-qualified URLs must include a scheme (i.e. 'http://www.google.com', not 'www.google.com'). Relative URLs will be relative to the current page within the extension. Defaults to the New Tab Page.</summary>
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

        /// <summary>The window to create the new tab in. Defaults to the $(topic:current-window)[current window].</summary>
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
