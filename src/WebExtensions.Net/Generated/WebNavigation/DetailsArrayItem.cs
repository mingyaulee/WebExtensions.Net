using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class DetailsArrayItem : BaseObject
    {
        /// <summary>True if the last navigation in this frame was interrupted by an error, i.e. the onErrorOccurred event fired.</summary>
        [JsonPropertyName("errorOccurred")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ErrorOccurred { get; set; }

        /// <summary>The ID of the frame. 0 indicates that this is the main frame; a positive value indicates the ID of a subframe.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>ID of frame that wraps the frame. Set to -1 of no parent frame exists.</summary>
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId { get; set; }

        /// <summary>The ID of the tab in which the frame is.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The URL currently associated with this frame.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
