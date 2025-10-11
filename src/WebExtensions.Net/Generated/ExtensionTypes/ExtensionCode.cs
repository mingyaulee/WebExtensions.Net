using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ExtensionTypes;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ExtensionCode : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("code")]
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Code { get; set; }
}
