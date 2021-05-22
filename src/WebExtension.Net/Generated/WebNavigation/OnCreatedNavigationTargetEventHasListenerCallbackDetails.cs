using System.Text.Json.Serialization;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public class OnCreatedNavigationTargetEventHasListenerCallbackDetails : BaseObject
    {
        private int _sourceFrameId;
        private int _sourceProcessId;
        private int _sourceTabId;
        private int _tabId;
        private double _timeStamp;
        private string _url;

        /// <summary>The ID of the frame with sourceTabId in which the navigation is triggered. 0 indicates the main frame.</summary>
        [JsonPropertyName("sourceFrameId")]
        public int SourceFrameId
        {
            get
            {
                InitializeProperty("sourceFrameId", _sourceFrameId);
                return _sourceFrameId;
            }
            set
            {
                _sourceFrameId = value;
            }
        }

        /// <summary>The ID of the process runs the renderer for the source tab.</summary>
        [JsonPropertyName("sourceProcessId")]
        public int SourceProcessId
        {
            get
            {
                InitializeProperty("sourceProcessId", _sourceProcessId);
                return _sourceProcessId;
            }
            set
            {
                _sourceProcessId = value;
            }
        }

        /// <summary>The ID of the tab in which the navigation is triggered.</summary>
        [JsonPropertyName("sourceTabId")]
        public int SourceTabId
        {
            get
            {
                InitializeProperty("sourceTabId", _sourceTabId);
                return _sourceTabId;
            }
            set
            {
                _sourceTabId = value;
            }
        }

        /// <summary>The ID of the tab in which the url is opened</summary>
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

        /// <summary>The time when the browser was about to create a new view, in milliseconds since the epoch.</summary>
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

        /// <summary>The URL to be opened in the new window.</summary>
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
