using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class MatchedRule : BaseObject
    {
        /// <summary>ID of the extension, if this rule belongs to a different extension.</summary>
        [JsonPropertyName("extensionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExtensionId { get; set; }

        /// <summary>A matching rule's ID.</summary>
        [JsonPropertyName("ruleId")]
        public int RuleId { get; set; }

        /// <summary>ID of the Ruleset this rule belongs to.</summary>
        [JsonPropertyName("rulesetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RulesetId { get; set; }
    }
}
