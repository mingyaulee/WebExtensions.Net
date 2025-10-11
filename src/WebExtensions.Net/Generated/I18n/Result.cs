using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n;

// Type Class
/// <summary>LanguageDetectionResult object that holds detected langugae reliability and array of DetectedLanguage</summary>
[BindAllProperties]
public partial class Result : BaseObject
{
    /// <summary>CLD detected language reliability</summary>
    [JsAccessPath("isReliable")]
    [JsonPropertyName("isReliable")]
    public bool IsReliable { get; set; }

    /// <summary>array of detectedLanguage</summary>
    [JsAccessPath("languages")]
    [JsonPropertyName("languages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<LanguageType> Languages { get; set; }
}
