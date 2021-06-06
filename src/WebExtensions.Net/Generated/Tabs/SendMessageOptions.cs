using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    public class SendMessageOptions : BaseObject
    {
        private int? _frameId;

        /// <summary>Send a message to a specific $(topic:frame_ids)[frame] identified by <c>frameId</c> instead of all frames in the tab.</summary>
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
    }
}
