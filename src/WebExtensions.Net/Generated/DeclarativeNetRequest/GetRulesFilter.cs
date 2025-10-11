using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class GetRulesFilter : BaseObject
{
    /// <summary>If specified, only rules with matching IDs are included.</summary>
    [JsAccessPath("ruleIds")]
    [JsonPropertyName("ruleIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<int> RuleIds { get; set; }
}
