using System.Text.Json.Serialization;

namespace WebExtensions.Net.Extension
{
    // Type Class
    /// <summary></summary>
    public partial class FetchProperties : BaseObject
    {
        private int? _tabId;
        private ViewType? _type;
        private int? _windowId;

        /// <summary>Find a view according to a tab id. If this field is omitted, returns all views.</summary>
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

        /// <summary>The type of view to get. If omitted, returns all views (including background pages and tabs). Valid values: 'tab', 'popup', 'sidebar'.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ViewType? Type
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

        /// <summary>The window to restrict the search to. If omitted, returns all views.</summary>
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
