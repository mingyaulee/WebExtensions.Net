using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class CallbackHighlightInfo : BaseObject
{
    /// <summary>All highlighted tabs in the window.</summary>
    [JsAccessPath("tabIds")]
    [JsonPropertyName("tabIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<int> TabIds { get; set; }

    /// <summary>The window whose tabs changed.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    public int WindowId { get; set; }
}
