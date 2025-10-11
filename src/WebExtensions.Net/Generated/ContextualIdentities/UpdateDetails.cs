using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.ContextualIdentities;

// Type Class
/// <summary>Details about the contextual identity being created.</summary>
[BindAllProperties]
public partial class UpdateDetails : BaseObject
{
    /// <summary>The color of the contextual identity.</summary>
    [JsAccessPath("color")]
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Color { get; set; }

    /// <summary>The icon of the contextual identity.</summary>
    [JsAccessPath("icon")]
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Icon { get; set; }

    /// <summary>The name of the contextual identity.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
}
