using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class MoveInfo : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("fromIndex")]
    [JsonPropertyName("fromIndex")]
    public int FromIndex { get; set; }

    /// <summary></summary>
    [JsAccessPath("toIndex")]
    [JsonPropertyName("toIndex")]
    public int ToIndex { get; set; }

    /// <summary></summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    public int WindowId { get; set; }
}
