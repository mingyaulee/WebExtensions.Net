using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SetPanelDetails : BaseObject
    {
        /// <summary>The url to the html file to show in a sidebar.  If set to the empty string (''), no sidebar is shown.</summary>
        [JsAccessPath("panel")]
        [JsonPropertyName("panel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Panel Panel { get; set; }

        /// <summary>Sets the sidebar url for the tab specified by tabId. Automatically resets when the tab is closed.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>Sets the sidebar url for the window specified by windowId.</summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
