using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ConnectInfo : BaseObject
    {
        /// <summary>Open a port to a specific $(topic:frame_ids)[frame] identified by <c>frameId</c> instead of all frames in the tab.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId { get; set; }

        /// <summary>Will be passed into onConnect for content scripts that are listening for the connection event.</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
    }
}
