using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities;

// Type Class
/// <summary>Information to filter the contextual identities being retrieved.</summary>
[BindAllProperties]
public partial class QueryDetails : BaseObject
{
    /// <summary>Filters the contextual identity by name.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
}
