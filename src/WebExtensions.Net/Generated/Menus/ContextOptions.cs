using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus
{
    // Type Class
    /// <summary></summary>
    public partial class ContextOptions : BaseObject
    {
        private string _bookmarkId;
        private string _context;
        private bool? _showDefaults;
        private int? _tabId;

        /// <summary>Required when context is 'bookmark'. Requires 'bookmark' permission.</summary>
        [JsonPropertyName("bookmarkId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BookmarkId
        {
            get
            {
                InitializeProperty("bookmarkId", _bookmarkId);
                return _bookmarkId;
            }
            set
            {
                _bookmarkId = value;
            }
        }

        /// <summary>ContextType to override, to allow menu items from other extensions in the menu. Currently only 'bookmark' and 'tab' are supported. showDefaults cannot be used with this option.</summary>
        [JsonPropertyName("context")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Context
        {
            get
            {
                InitializeProperty("context", _context);
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        /// <summary>Whether to also include default menu items in the menu.</summary>
        [JsonPropertyName("showDefaults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowDefaults
        {
            get
            {
                InitializeProperty("showDefaults", _showDefaults);
                return _showDefaults;
            }
            set
            {
                _showDefaults = value;
            }
        }

        /// <summary>Required when context is 'tab'. Requires 'tabs' permission.</summary>
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
    }
}
