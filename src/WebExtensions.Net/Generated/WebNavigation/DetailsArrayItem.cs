using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    public class DetailsArrayItem : BaseObject
    {
        private bool? _errorOccurred;
        private int _frameId;
        private int _parentFrameId;
        private int _tabId;
        private string _url;

        /// <summary>True if the last navigation in this frame was interrupted by an error, i.e. the onErrorOccurred event fired.</summary>
        [JsonPropertyName("errorOccurred")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ErrorOccurred
        {
            get
            {
                InitializeProperty("errorOccurred", _errorOccurred);
                return _errorOccurred;
            }
            set
            {
                _errorOccurred = value;
            }
        }

        /// <summary>The ID of the frame. 0 indicates that this is the main frame; a positive value indicates the ID of a subframe.</summary>
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

        /// <summary>The ID of the tab in which the frame is.</summary>
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

        /// <summary>The URL currently associated with this frame.</summary>
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
