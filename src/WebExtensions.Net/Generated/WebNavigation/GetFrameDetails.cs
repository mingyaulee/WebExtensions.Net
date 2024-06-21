using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Information about the frame to retrieve information about.</summary>
    [BindAllProperties]
    public partial class GetFrameDetails : BaseObject
    {
        /// <summary>The ID of the frame in the given tab.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>The ID of the process runs the renderer for this tab.</summary>
        [JsAccessPath("processId")]
        [JsonPropertyName("processId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProcessId { get; set; }

        /// <summary>The ID of the tab in which the frame is.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }
    }
}
