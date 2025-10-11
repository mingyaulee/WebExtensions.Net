using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class UpdateProperties : BaseObject
{
    /// <summary>Whether the tab should be active. Does not affect whether the window is focused (see $(ref:windows.update)).</summary>
    [JsAccessPath("active")]
    [JsonPropertyName("active")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Active { get; set; }

    /// <summary>Whether the tab can be discarded automatically by the browser when resources are low.</summary>
    [JsAccessPath("autoDiscardable")]
    [JsonPropertyName("autoDiscardable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoDiscardable { get; set; }

    /// <summary>Adds or removes the tab from the current selection.</summary>
    [JsAccessPath("highlighted")]
    [JsonPropertyName("highlighted")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Highlighted { get; set; }

    /// <summary>Whether the load should replace the current history entry for the tab.</summary>
    [JsAccessPath("loadReplace")]
    [JsonPropertyName("loadReplace")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LoadReplace { get; set; }

    /// <summary>Whether the tab should be muted.</summary>
    [JsAccessPath("muted")]
    [JsonPropertyName("muted")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Muted { get; set; }

    /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as this tab.</summary>
    [JsAccessPath("openerTabId")]
    [JsonPropertyName("openerTabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OpenerTabId { get; set; }

    /// <summary>Whether the tab should be pinned.</summary>
    [JsAccessPath("pinned")]
    [JsonPropertyName("pinned")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Pinned { get; set; }

    /// <summary>The ID of this tab's successor. If specified, the successor tab must be in the same window as this tab.</summary>
    [JsAccessPath("successorTabId")]
    [JsonPropertyName("successorTabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SuccessorTabId { get; set; }

    /// <summary>A URL to navigate the tab to.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
