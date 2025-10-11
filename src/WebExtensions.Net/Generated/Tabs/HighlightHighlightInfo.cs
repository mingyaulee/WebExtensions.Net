using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class HighlightHighlightInfo : BaseObject
{
    /// <summary>If true, the $(ref:windows.Window) returned will have a <c>tabs</c> property that contains a list of the $(ref:tabs.Tab) objects. The <c>Tab</c> objects only contain the <c>url</c>, <c>title</c> and <c>favIconUrl</c> properties if the extension's manifest file includes the <c>"tabs"</c> permission. If false, the $(ref:windows.Window) won't have the <c>tabs</c> property.</summary>
    [JsAccessPath("populate")]
    [JsonPropertyName("populate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Populate { get; set; }

    /// <summary>One or more tab indices to highlight.</summary>
    [JsAccessPath("tabs")]
    [JsonPropertyName("tabs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HighlightInfoTabs Tabs { get; set; }

    /// <summary>The window that contains the tabs.</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
