using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Theme;

// Type Class
/// <summary>Info provided in the onUpdated listener.</summary>
[BindAllProperties]
public partial class ThemeUpdateInfo : BaseObject
{
    /// <summary>The new theme after update</summary>
    [JsAccessPath("theme")]
    [JsonPropertyName("theme")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Theme { get; set; }

    /// <summary>The id of the window the theme has been applied to</summary>
    [JsAccessPath("windowId")]
    [JsonPropertyName("windowId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WindowId { get; set; }
}
