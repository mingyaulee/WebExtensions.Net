using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class DeleteUrlDetails : BaseObject
{
    /// <summary>The URL to remove.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
