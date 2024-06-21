using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class OnCreatedNavigationTargetEventCallbackDetails : BaseObject
    {
        /// <summary>The ID of the frame with sourceTabId in which the navigation is triggered. 0 indicates the main frame.</summary>
        [JsAccessPath("sourceFrameId")]
        [JsonPropertyName("sourceFrameId")]
        public int SourceFrameId { get; set; }

        /// <summary>The ID of the process runs the renderer for the source tab.</summary>
        [JsAccessPath("sourceProcessId")]
        [JsonPropertyName("sourceProcessId")]
        public int SourceProcessId { get; set; }

        /// <summary>The ID of the tab in which the navigation is triggered.</summary>
        [JsAccessPath("sourceTabId")]
        [JsonPropertyName("sourceTabId")]
        public int SourceTabId { get; set; }

        /// <summary>The ID of the tab in which the url is opened</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary>The time when the browser was about to create a new view, in milliseconds since the epoch.</summary>
        [JsAccessPath("timeStamp")]
        [JsonPropertyName("timeStamp")]
        public EpochTime TimeStamp { get; set; }

        /// <summary>The URL to be opened in the new window.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
