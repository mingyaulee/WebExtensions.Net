using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime;

// Type Class
/// <summary>An object containing information about the current browser.</summary>
[BindAllProperties]
public partial class BrowserInfo : BaseObject
{
    /// <summary>The browser's build ID/date, for example '20160101'.</summary>
    [JsAccessPath("buildID")]
    [JsonPropertyName("buildID")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string BuildID { get; set; }

    /// <summary>The name of the browser, for example 'Firefox'.</summary>
    [JsAccessPath("name")]
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>The name of the browser vendor, for example 'Mozilla'.</summary>
    [JsAccessPath("vendor")]
    [JsonPropertyName("vendor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Vendor { get; set; }

    /// <summary>The browser's version, for example '42.0.0' or '0.8.1pre'.</summary>
    [JsAccessPath("version")]
    [JsonPropertyName("version")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Version { get; set; }
}
