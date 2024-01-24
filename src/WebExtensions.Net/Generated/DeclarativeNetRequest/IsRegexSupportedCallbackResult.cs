using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class IsRegexSupportedCallbackResult : BaseObject
    {
        /// <summary>Whether the given regex is supported</summary>
        [JsonPropertyName("isSupported")]
        public bool IsSupported { get; set; }

        /// <summary>Specifies the reason why the regular expression is not supported. Only provided if 'isSupported' is false.</summary>
        [JsonPropertyName("reason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UnsupportedRegexReason? Reason { get; set; }
    }
}
