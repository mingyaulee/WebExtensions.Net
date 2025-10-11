using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>The manifest details of the available update.</summary>
[BindAllProperties]
public partial class OnUpdateAvailableEventCallbackDetails : BaseObject
{
    /// <summary>The version number of the available update.</summary>
    [JsAccessPath("version")]
    [JsonPropertyName("version")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Version { get; set; }
}
