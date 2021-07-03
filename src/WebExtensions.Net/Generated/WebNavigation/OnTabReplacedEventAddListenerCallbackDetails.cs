using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public partial class OnTabReplacedEventAddListenerCallbackDetails : BaseObject
    {
        private int _replacedTabId;
        private int _tabId;
        private EpochTime _timeStamp;

        /// <summary>The ID of the tab that was replaced.</summary>
        [JsonPropertyName("replacedTabId")]
        public int ReplacedTabId
        {
            get
            {
                InitializeProperty("replacedTabId", _replacedTabId);
                return _replacedTabId;
            }
            set
            {
                _replacedTabId = value;
            }
        }

        /// <summary>The ID of the tab that replaced the old tab.</summary>
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

        /// <summary>The time when the replacement happened, in milliseconds since the epoch.</summary>
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
    }
}
