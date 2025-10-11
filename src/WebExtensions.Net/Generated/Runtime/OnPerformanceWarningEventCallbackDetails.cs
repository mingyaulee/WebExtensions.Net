using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class OnPerformanceWarningEventCallbackDetails : BaseObject
{
    /// <summary>The performance warning event category, e.g. 'content_script'.</summary>
    [JsAccessPath("category")]
    [JsonPropertyName("category")]
    public OnPerformanceWarningCategory Category { get; set; }

    /// <summary>An explanation of what the warning means, and hopefully how to address it.</summary>
    [JsAccessPath("description")]
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; set; }

    /// <summary>The performance warning event severity, e.g. 'high'.</summary>
    [JsAccessPath("severity")]
    [JsonPropertyName("severity")]
    public OnPerformanceWarningSeverity Severity { get; set; }

    /// <summary>The $(ref:tabs.Tab) that the performance warning relates to, if any.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }
}
