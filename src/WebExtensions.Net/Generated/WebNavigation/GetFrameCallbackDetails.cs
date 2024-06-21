using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary>Information about the requested frame, null if the specified frame ID and/or tab ID are invalid.</summary>
    [BindAllProperties]
    public partial class GetFrameCallbackDetails : BaseObject
    {
        /// <summary>True if the last navigation in this frame was interrupted by an error, i.e. the onErrorOccurred event fired.</summary>
        [JsAccessPath("errorOccurred")]
        [JsonPropertyName("errorOccurred")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ErrorOccurred { get; set; }

        /// <summary>The ID of the frame. 0 indicates that this is the main frame; a positive value indicates the ID of a subframe.</summary>
        [JsAccessPath("frameId")]
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>ID of frame that wraps the frame. Set to -1 of no parent frame exists.</summary>
        [JsAccessPath("parentFrameId")]
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId { get; set; }

        /// <summary>The ID of the tab in which the frame is.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The URL currently associated with this frame, if the frame identified by the frameId existed at one point in the given tab. The fact that an URL is associated with a given frameId does not imply that the corresponding frame still exists.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
