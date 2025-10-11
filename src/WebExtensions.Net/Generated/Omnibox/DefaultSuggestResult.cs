using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Omnibox;

// Type Class
/// <summary>A suggest result.</summary>
[BindAllProperties]
public partial class DefaultSuggestResult : BaseObject
{
    /// <summary>The text that is displayed in the URL dropdown.</summary>
    [JsAccessPath("description")]
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; set; }
}
