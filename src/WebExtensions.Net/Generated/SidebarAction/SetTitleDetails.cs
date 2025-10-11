using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class SetTitleDetails : BaseObject
{
    /// <summary>Sets the sidebar title for the tab specified by tabId. Automatically resets when the tab is closed.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }

    /// <summary>The string the sidebar action should display when moused over.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Title Title { get; set; }

    /// <summary>Sets the sidebar title for the window specified by windowId.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
