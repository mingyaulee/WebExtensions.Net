using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Devtools.InspectedWindow;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ReloadOptions : BaseObject
{
    /// <summary>When true, the loader will bypass the cache for all inspected page resources loaded before the <c>load</c> event is fired. The effect is similar to pressing Ctrl+Shift+R in the inspected window or within the Developer Tools window.</summary>
    [JsAccessPath("ignoreCache")]
    [JsonPropertyName("ignoreCache")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IgnoreCache { get; set; }

    /// <summary>If specified, the script will be injected into every frame of the inspected page immediately upon load, before any of the frame's scripts. The script will not be injected after subsequent reloads-for example, if the user presses Ctrl+R.</summary>
    [JsAccessPath("injectedScript")]
    [JsonPropertyName("injectedScript")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string InjectedScript { get; set; }

    /// <summary>If specified, the string will override the value of the <c>User-Agent</c> HTTP header that's sent while loading the resources of the inspected page. The string will also override the value of the <c>navigator.userAgent</c> property that's returned to any scripts that are running within the inspected page.</summary>
    [JsAccessPath("userAgent")]
    [JsonPropertyName("userAgent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string UserAgent { get; set; }
}
