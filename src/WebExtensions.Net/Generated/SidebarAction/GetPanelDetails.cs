using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class GetPanelDetails : BaseObject
    {
        /// <summary>Specify the tab to get the panel from. If no tab nor window is specified, the global panel is returned.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>Specify the window to get the panel from. If no tab nor window is specified, the global panel is returned.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
