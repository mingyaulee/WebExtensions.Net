using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class GetDisabledRuleIdsOptions : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("rulesetId")]
        [JsonPropertyName("rulesetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RulesetId { get; set; }
    }
}
