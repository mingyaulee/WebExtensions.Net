using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RegexOptions : BaseObject
    {
        /// <summary>Whether the 'regex' specified is case sensitive.</summary>
        [JsonPropertyName("isCaseSensitive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsCaseSensitive { get; set; }

        /// <summary>The regular expresson to check.</summary>
        [JsonPropertyName("regex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Regex { get; set; }

        /// <summary>Whether the 'regex' specified requires capturing. Capturing is only required for redirect rules which specify a 'regexSubstition' action.</summary>
        [JsonPropertyName("requireCapturing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireCapturing { get; set; }
    }
}
