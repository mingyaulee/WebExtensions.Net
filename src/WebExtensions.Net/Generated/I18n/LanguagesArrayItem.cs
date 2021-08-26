using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.I18n
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class LanguagesArrayItem : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageCode Language { get; set; }

        /// <summary>The percentage of the detected language</summary>
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; }
    }
}
