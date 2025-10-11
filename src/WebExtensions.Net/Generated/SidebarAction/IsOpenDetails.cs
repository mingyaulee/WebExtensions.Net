using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class IsOpenDetails : BaseObject
{
    /// <summary>Specify the window to get the openness from.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
