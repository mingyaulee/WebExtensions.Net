using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.DeclarativeNetRequest;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Rule : BaseObject
{
    /// <summary>The action to take if this rule is matched.</summary>
    [JsAccessPath("action")]
    [JsonPropertyName("action")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RuleAction Action { get; set; }

    /// <summary>The condition under which this rule is triggered.</summary>
    [JsAccessPath("condition")]
    [JsonPropertyName("condition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Condition Condition { get; set; }

    /// <summary>An id which uniquely identifies a rule. Mandatory and should be >= 1.</summary>
    [JsAccessPath("id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>Rule priority. Defaults to 1. When specified, should be >= 1</summary>
    [JsAccessPath("priority")]
    [JsonPropertyName("priority")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Priority { get; set; }
}
