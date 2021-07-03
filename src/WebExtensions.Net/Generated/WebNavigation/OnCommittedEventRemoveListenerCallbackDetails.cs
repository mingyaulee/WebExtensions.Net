using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public partial class OnCommittedEventRemoveListenerCallbackDetails : BaseObject
    {
        private int _frameId;
        private int _tabId;
        private EpochTime _timeStamp;
        private string _url;

        /// <summary>0 indicates the navigation happens in the tab content window; a positive value indicates navigation in a subframe. Frame IDs are unique within a tab.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId
        {
            get
            {
                InitializeProperty("frameId", _frameId);
                return _frameId;
            }
            set
            {
                _frameId = value;
            }
        }

        /// <summary>The ID of the tab in which the navigation occurs.</summary>
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

        /// <summary>The time when the navigation was committed, in milliseconds since the epoch.</summary>
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

        /// <summary></summary>
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
    }
}
