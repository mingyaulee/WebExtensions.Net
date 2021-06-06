using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class RemoveListenerCallbackZoomChangeInfo : BaseObject
    {
        private double _newZoomFactor;
        private double _oldZoomFactor;
        private int _tabId;
        private ZoomSettings _zoomSettings;

        /// <summary></summary>
        [JsonPropertyName("newZoomFactor")]
        public double NewZoomFactor
        {
            get
            {
                InitializeProperty("newZoomFactor", _newZoomFactor);
                return _newZoomFactor;
            }
            set
            {
                _newZoomFactor = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("oldZoomFactor")]
        public double OldZoomFactor
        {
            get
            {
                InitializeProperty("oldZoomFactor", _oldZoomFactor);
                return _oldZoomFactor;
            }
            set
            {
                _oldZoomFactor = value;
            }
        }

        /// <summary></summary>
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

        /// <summary></summary>
        [JsonPropertyName("zoomSettings")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZoomSettings ZoomSettings
        {
            get
            {
                InitializeProperty("zoomSettings", _zoomSettings);
                return _zoomSettings;
            }
            set
            {
                _zoomSettings = value;
            }
        }
    }
}
