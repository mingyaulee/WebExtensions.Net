using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RemoveListenerCallbackZoomChangeInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("newZoomFactor")]
        public double NewZoomFactor { get; set; }

        /// <summary></summary>
        [JsonPropertyName("oldZoomFactor")]
        public double OldZoomFactor { get; set; }

        /// <summary></summary>
        [JsonPropertyName("tabId")]
        public int TabId { get; set; }

        /// <summary></summary>
        [JsonPropertyName("zoomSettings")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZoomSettings ZoomSettings { get; set; }
    }
}
