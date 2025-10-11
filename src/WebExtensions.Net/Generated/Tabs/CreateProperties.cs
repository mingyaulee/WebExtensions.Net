using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class CreateProperties : BaseObject
{
    /// <summary>Whether the tab should become the active tab in the window. Does not affect whether the window is focused (see $(ref:windows.update)). Defaults to <c>true</c>.</summary>
    [JsAccessPath("active")]
    [JsonPropertyName("active")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Active { get; set; }

    /// <summary>The CookieStoreId for the tab that opened this tab.</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>Whether the tab is marked as 'discarded' when created.</summary>
    [JsAccessPath("discarded")]
    [JsonPropertyName("discarded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Discarded { get; set; }

    /// <summary>The position the tab should take in the window. The provided value will be clamped to between zero and the number of tabs in the window.</summary>
    [JsAccessPath("index")]
    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Index { get; set; }

    /// <summary>Whether the tab should be muted when created.</summary>
    [JsAccessPath("muted")]
    [JsonPropertyName("muted")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Muted { get; set; }

    /// <summary>The ID of the tab that opened this tab. If specified, the opener tab must be in the same window as the newly created tab.</summary>
    [JsAccessPath("openerTabId")]
    [JsonPropertyName("openerTabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OpenerTabId { get; set; }

    /// <summary>Whether the document in the tab should be opened in reader mode.</summary>
    [JsAccessPath("openInReaderMode")]
    [JsonPropertyName("openInReaderMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OpenInReaderMode { get; set; }

    /// <summary>Whether the tab should be pinned. Defaults to <c>false</c></summary>
    [JsAccessPath("pinned")]
    [JsonPropertyName("pinned")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Pinned { get; set; }

    /// <summary>The title used for display if the tab is created in discarded mode.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    /// <summary>The URL to navigate the tab to initially. Fully-qualified URLs must include a scheme (i.e. 'http://www.google.com', not 'www.google.com'). Relative URLs will be relative to the current page within the extension. Defaults to the New Tab Page.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }

    /// <summary>The window to create the new tab in. Defaults to the $(topic:current-window)[current window].</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
