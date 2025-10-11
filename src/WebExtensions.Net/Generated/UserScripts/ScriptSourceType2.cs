using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.UserScripts;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ScriptSourceType2 : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("code")]
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Code { get; set; }
}
