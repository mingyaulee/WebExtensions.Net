using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TabGroups;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class UpdateProperties : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("collapsed")]
    [JsonPropertyName("collapsed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Collapsed { get; set; }

    /// <summary></summary>
    [JsAccessPath("color")]
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Color? Color { get; set; }

    /// <summary></summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }
}
