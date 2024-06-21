using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ZoomChangeInfo : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("newZoomFactor")]
        [JsonPropertyName("newZoomFactor")]
        public double NewZoomFactor { get; set; }

        /// <summary></summary>
        [JsAccessPath("oldZoomFactor")]
        [JsonPropertyName("oldZoomFactor")]
        public double OldZoomFactor { get; set; }

        /// <summary></summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary></summary>
        [JsAccessPath("zoomSettings")]
        [JsonPropertyName("zoomSettings")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZoomSettings ZoomSettings { get; set; }
    }
}
