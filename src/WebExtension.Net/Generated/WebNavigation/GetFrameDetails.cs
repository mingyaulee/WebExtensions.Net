using System.Text.Json.Serialization;

namespace WebExtension.Net.WebNavigation
{
    // Type Class
    /// <summary>Information about the frame to retrieve information about.</summary>
    public class GetFrameDetails : BaseObject
    {
        private int _frameId;
        private int? _processId;
        private int _tabId;

        /// <summary>The ID of the frame in the given tab.</summary>
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

        /// <summary>The ID of the process runs the renderer for this tab.</summary>
        [JsonPropertyName("processId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProcessId
        {
            get
            {
                InitializeProperty("processId", _processId);
                return _processId;
            }
            set
            {
                _processId = value;
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
    }
}
