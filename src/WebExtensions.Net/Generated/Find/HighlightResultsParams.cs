using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Find;

// Type Class
/// <summary>highlightResults parameters</summary>
[BindAllProperties]
public partial class HighlightResultsParams : BaseObject
{
    /// <summary>Don't scroll to highlighted item.</summary>
    [JsAccessPath("noScroll")]
    [JsonPropertyName("noScroll")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NoScroll { get; set; }

    /// <summary>Found range to be highlighted. Default highlights all ranges.</summary>
    [JsAccessPath("rangeIndex")]
    [JsonPropertyName("rangeIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RangeIndex { get; set; }

    /// <summary>Tab to highlight. Defaults to the active tab.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }
}
