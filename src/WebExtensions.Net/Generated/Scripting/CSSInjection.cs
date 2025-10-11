using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class CSSInjection : BaseObject
{
    /// <summary>A string containing the CSS to inject. Exactly one of <c>files</c> and <c>css</c> must be specified.</summary>
    [JsAccessPath("css")]
    [JsonPropertyName("css")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Css { get; set; }

    /// <summary>The path of the CSS files to inject, relative to the extension's root directory. Exactly one of <c>files</c> and <c>css</c> must be specified.</summary>
    [JsAccessPath("files")]
    [JsonPropertyName("files")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> Files { get; set; }

    /// <summary>The style origin for the injection. Defaults to <c>'AUTHOR'</c>.</summary>
    [JsAccessPath("origin")]
    [JsonPropertyName("origin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Origin? Origin { get; set; }

    /// <summary>Details specifying the target into which to inject the CSS.</summary>
    [JsAccessPath("target")]
    [JsonPropertyName("target")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InjectionTarget Target { get; set; }
}
