using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public partial class HasListenerCallbackActiveInfo : BaseObject
    {
        private int? _previousTabId;
        private int _tabId;
        private int _windowId;

        /// <summary>The ID of the tab that was previously active, if that tab is still open.</summary>
        [JsonPropertyName("previousTabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PreviousTabId
        {
            get
            {
                InitializeProperty("previousTabId", _previousTabId);
                return _previousTabId;
            }
            set
            {
                _previousTabId = value;
            }
        }

        /// <summary>The ID of the tab that has become active.</summary>
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

        /// <summary>The ID of the window the active tab changed inside of.</summary>
        [JsonPropertyName("windowId")]
        public int WindowId
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
