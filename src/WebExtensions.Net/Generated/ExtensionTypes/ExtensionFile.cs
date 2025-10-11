using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.ExtensionTypes;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ExtensionFile : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("file")]
    [JsonPropertyName("file")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExtensionUrl File { get; set; }
}
