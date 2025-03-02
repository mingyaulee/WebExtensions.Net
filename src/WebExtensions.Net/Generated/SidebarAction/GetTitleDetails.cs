using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class GetTitleDetails : BaseObject
    {
        /// <summary>Specify the tab to get the title from. If no tab nor window is specified, the global title is returned.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>Specify the window to get the title from. If no tab nor window is specified, the global title is returned.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
