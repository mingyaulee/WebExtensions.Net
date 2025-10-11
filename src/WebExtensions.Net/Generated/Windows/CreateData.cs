using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Windows;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class CreateData : BaseObject
{
    /// <summary>Allow scripts to close the window.</summary>
    [JsAccessPath("allowScriptsToClose")]
    [JsonPropertyName("allowScriptsToClose")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AllowScriptsToClose { get; set; }

    /// <summary>The CookieStoreId to use for all tabs that were created when the window is opened.</summary>
    [JsAccessPath("cookieStoreId")]
    [JsonPropertyName("cookieStoreId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string CookieStoreId { get; set; }

    /// <summary>If true, opens an active window. If false, opens an inactive window.</summary>
    [JsAccessPath("focused")]
    [JsonPropertyName("focused")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Focused { get; set; }

    /// <summary>The height in pixels of the new window, including the frame. If not specified defaults to a natural height.</summary>
    [JsAccessPath("height")]
    [JsonPropertyName("height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; set; }

    /// <summary>Whether the new window should be an incognito window.</summary>
    [JsAccessPath("incognito")]
    [JsonPropertyName("incognito")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Incognito { get; set; }

    /// <summary>The number of pixels to position the new window from the left edge of the screen. If not specified, the new window is offset naturally from the last focused window. This value is ignored for panels.</summary>
    [JsAccessPath("left")]
    [JsonPropertyName("left")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Left { get; set; }

    /// <summary>The initial state of the window. The 'minimized', 'maximized' and 'fullscreen' states cannot be combined with 'left', 'top', 'width' or 'height'.</summary>
    [JsAccessPath("state")]
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WindowState? State { get; set; }

    /// <summary>The id of the tab for which you want to adopt to the new window.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }

    /// <summary>A string to add to the beginning of the window title.</summary>
    [JsAccessPath("titlePreface")]
    [JsonPropertyName("titlePreface")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string TitlePreface { get; set; }

    /// <summary>The number of pixels to position the new window from the top edge of the screen. If not specified, the new window is offset naturally from the last focused window. This value is ignored for panels.</summary>
    [JsAccessPath("top")]
    [JsonPropertyName("top")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Top { get; set; }

    /// <summary>Specifies what type of browser window to create. The 'panel' and 'detached_panel' types create a popup unless the '--enable-panels' flag is set.</summary>
    [JsAccessPath("type")]
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CreateType? Type { get; set; }

    /// <summary>A URL or array of URLs to open as tabs in the window. Fully-qualified URLs must include a scheme (i.e. 'http://www.google.com', not 'www.google.com'). Relative URLs will be relative to the current page within the extension. Defaults to the New Tab Page.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Url Url { get; set; }

    /// <summary>The width in pixels of the new window, including the frame. If not specified defaults to a natural width.</summary>
    [JsAccessPath("width")]
    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }
}
