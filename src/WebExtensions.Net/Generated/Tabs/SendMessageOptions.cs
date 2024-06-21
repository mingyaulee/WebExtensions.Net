using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SendMessageOptions : BaseObject
    {
        /// <summary>Send a message to a specific $(topic:frame_ids)[frame] identified by <c>frameId</c> instead of all frames in the tab.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameId { get; set; }
    }
}
