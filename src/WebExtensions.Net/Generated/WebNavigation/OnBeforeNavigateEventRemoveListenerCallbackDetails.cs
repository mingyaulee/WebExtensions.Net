using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnBeforeNavigateEventRemoveListenerCallbackDetails : BaseObject
    {
        /// <summary>0 indicates the navigation happens in the tab content window; a positive value indicates navigation in a subframe. Frame IDs are unique for a given tab and process.</summary>
        [JsonPropertyName("frameId")]
        public int FrameId { get; set; }

        /// <summary>ID of frame that wraps the frame. Set to -1 of no parent frame exists.</summary>
        [JsonPropertyName("parentFrameId")]
        public int ParentFrameId { get; set; }

        /// <summary>The ID of the tab in which the navigation is about to occur.</summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The time when the browser was about to start the navigation, in milliseconds since the epoch.</summary>
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
