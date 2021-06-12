using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    // Type Class
    /// <summary>LanguageDetectionResult object that holds detected langugae reliability and array of DetectedLanguage</summary>
    public partial class Result : BaseObject
    {
        private bool _isReliable;
        private IEnumerable<LanguagesArrayItem> _languages;

        /// <summary>CLD detected language reliability</summary>
        [JsonPropertyName("isReliable")]
        public bool IsReliable
        {
            get
            {
                InitializeProperty("isReliable", _isReliable);
                return _isReliable;
            }
            set
            {
                _isReliable = value;
            }
        }

        /// <summary>array of detectedLanguage</summary>
        [JsonPropertyName("languages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<LanguagesArrayItem> Languages
        {
            get
            {
                InitializeProperty("languages", _languages);
                return _languages;
            }
            set
            {
                _languages = value;
            }
        }
    }
}
