using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public partial class OnBeforeNavigateEventHasListenerCallbackDetails : BaseObject
    {
        private int _frameId;
        private int _parentFrameId;
        private int _tabId;
        private long _timeStamp;
        private string _url;

        /// <summary>0 indicates the navigation happens in the tab content window; a positive value indicates navigation in a subframe. Frame IDs are unique for a given tab and process.</summary>
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

        /// <summary>ID of frame that wraps the frame. Set to -1 of no parent frame exists.</summary>
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId
        {
            get
            {
                InitializeProperty("parentFrameId", _parentFrameId);
                return _parentFrameId;
            }
            set
            {
                _parentFrameId = value;
            }
        }

        /// <summary>The ID of the tab in which the navigation is about to occur.</summary>
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

        /// <summary>The time when the browser was about to start the navigation, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public long TimeStamp
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
