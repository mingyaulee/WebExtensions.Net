using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ScriptSourceType1 : BaseObject
{
    /// <summary>The path of the JavaScript file to inject relative to the extension's root directory.</summary>
    [JsAccessPath("file")]
    [JsonPropertyName("file")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string File { get; set; }
}
