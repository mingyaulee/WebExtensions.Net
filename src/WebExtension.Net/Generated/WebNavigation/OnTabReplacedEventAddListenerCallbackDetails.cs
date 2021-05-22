using System.Text.Json.Serialization;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public class OnTabReplacedEventAddListenerCallbackDetails : BaseObject
    {
        private int _replacedTabId;
        private int _tabId;
        private double _timeStamp;

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
        public double TimeStamp
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