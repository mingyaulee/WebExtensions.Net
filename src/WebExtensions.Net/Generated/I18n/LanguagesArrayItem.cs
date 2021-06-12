using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    // Type Class
    /// <summary></summary>
    public partial class LanguagesArrayItem : BaseObject
    {
        private LanguageCode _language;
        private int _percentage;

        /// <summary></summary>
        [JsonPropertyName("language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageCode Language
        {
            get
            {
                InitializeProperty("language", _language);
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        /// <summary>The percentage of the detected language</summary>
        [JsonPropertyName("percentage")]
        public int Percentage
        {
            get
            {
                InitializeProperty("percentage", _percentage);
                return _percentage;
            }
            set
            {
                _percentage = value;
            }
        }
    }
}
