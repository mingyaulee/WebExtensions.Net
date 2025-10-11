using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class InjectionTarget : BaseObject
{
    /// <summary>Whether the script should inject into all frames within the tab. Defaults to false. This must not be true if <c>frameIds</c> is specified.</summary>
    [JsAccessPath("allFrames")]
    [JsonPropertyName("allFrames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllFrames { get; set; }

    /// <summary>The IDs of specific frames to inject into.</summary>
    [JsAccessPath("frameIds")]
    [JsonPropertyName("frameIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<int> FrameIds { get; set; }

    /// <summary>The ID of the tab into which to inject.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    public int TabId { get; set; }
}
