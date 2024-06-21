using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class UpdateSessionRulesOptions : BaseObject
    {
        /// <summary>Rules to add.</summary>
        [JsAccessPath("addRules")]
        [JsonPropertyName("addRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Rule> AddRules { get; set; }

        /// <summary>IDs of the rules to remove. Any invalid IDs will be ignored.</summary>
        [JsAccessPath("removeRuleIds")]
        [JsonPropertyName("removeRuleIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int> RemoveRuleIds { get; set; }
    }
}
