using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Scripting;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ContentScriptFilter : BaseObject
{
    /// <summary>The IDs of specific scripts to retrieve with <c>getRegisteredContentScripts()</c> or to unregister with <c>unregisterContentScripts()</c>.</summary>
    [JsAccessPath("ids")]
    [JsonPropertyName("ids")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> Ids { get; set; }
}
