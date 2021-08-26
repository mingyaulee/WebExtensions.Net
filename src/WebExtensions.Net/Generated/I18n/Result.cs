using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    // Type Class
    /// <summary>LanguageDetectionResult object that holds detected langugae reliability and array of DetectedLanguage</summary>
    [BindAllProperties]
    public partial class Result : BaseObject
    {
        /// <summary>CLD detected language reliability</summary>
        [JsonPropertyName("isReliable")]
        public bool IsReliable { get; set; }

        /// <summary>array of detectedLanguage</summary>
        [JsonPropertyName("languages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<LanguagesArrayItem> Languages { get; set; }
    }
}
