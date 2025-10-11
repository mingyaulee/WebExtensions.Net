using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class LanguageType : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("language")]
    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LanguageCode Language { get; set; }

    /// <summary>The percentage of the detected language</summary>
    [JsAccessPath("percentage")]
    [JsonPropertyName("percentage")]
    public int Percentage { get; set; }
}
