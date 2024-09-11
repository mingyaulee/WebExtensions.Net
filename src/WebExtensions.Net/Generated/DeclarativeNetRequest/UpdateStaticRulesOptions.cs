using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UpdateStaticRulesOptions : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("disableRuleIds")]
        [JsonPropertyName("disableRuleIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> DisableRuleIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("enableRuleIds")]
        [JsonPropertyName("enableRuleIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> EnableRuleIds { get; set; }

        /// <summary></summary>
        [JsAccessPath("rulesetId")]
        [JsonPropertyName("rulesetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RulesetId { get; set; }
    }
}
