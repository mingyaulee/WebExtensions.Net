using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class TestMatchOutcomeOptions : BaseObject
    {
        /// <summary>Whether to account for rules from other installed extensions during rule evaluation.</summary>
        [JsAccessPath("includeOtherExtensions")]
        [JsonPropertyName("includeOtherExtensions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeOtherExtensions { get; set; }
    }
}
