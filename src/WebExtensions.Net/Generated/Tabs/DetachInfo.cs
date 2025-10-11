using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class DetachInfo : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("oldPosition")]
    [JsonPropertyName("oldPosition")]
    public int OldPosition { get; set; }

    /// <summary></summary>
    [JsAccessPath("oldWindowId")]
    [JsonPropertyName("oldWindowId")]
    public int OldWindowId { get; set; }
}
