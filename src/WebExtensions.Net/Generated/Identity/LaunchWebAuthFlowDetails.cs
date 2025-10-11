using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Identity;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class LaunchWebAuthFlowDetails : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("interactive")]
    [JsonPropertyName("interactive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Interactive { get; set; }

    /// <summary></summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpUrl Url { get; set; }
}
