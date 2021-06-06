using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class ConnectInfo : BaseObject
    {
        private int? _frameId;
        private string _name;

        /// <summary>Open a port to a specific $(topic:frame_ids)[frame] identified by <c>frameId</c> instead of all frames in the tab.</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId
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

        /// <summary>Will be passed into onConnect for content scripts that are listening for the connection event.</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
