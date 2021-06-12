using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowserAction
{
    // Type Class
    /// <summary>Specifies to which tab or window the value should be set, or from which one it should be retrieved. If no tab nor window is specified, the global value is set or retrieved.</summary>
    public partial class Details : BaseObject
    {
        private int? _tabId;
        private int? _windowId;

        /// <summary>When setting a value, it will be specific to the specified tab, and will automatically reset when the tab navigates. When getting, specifies the tab to get the value from; if there is no tab-specific value, the window one will be inherited.</summary>
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

        /// <summary>When setting a value, it will be specific to the specified window. When getting, specifies the window to get the value from; if there is no window-specific value, the global one will be inherited.</summary>
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
