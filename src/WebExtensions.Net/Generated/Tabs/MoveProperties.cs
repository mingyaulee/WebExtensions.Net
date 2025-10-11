using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class MoveProperties : BaseObject
{
    /// <summary>The position to move the window to. -1 will place the tab at the end of the window.</summary>
    [JsAccessPath("index")]
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>Defaults to the window the tab is currently in.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
