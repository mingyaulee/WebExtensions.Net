using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData;

// Type Class
/// <summary>A set of data types. Missing data types are interpreted as <c>false</c>.</summary>
[BindAllProperties]
public partial class DataTypeSet : BaseObject
{
    /// <summary>The browser's cache. Note: when removing data, this clears the <em>entire</em> cache: it is not limited to the range you specify.</summary>
    [JsAccessPath("cache")]
    [JsonPropertyName("cache")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Cache { get; set; }

    /// <summary>The browser's cookies.</summary>
    [JsAccessPath("cookies")]
    [JsonPropertyName("cookies")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Cookies { get; set; }

    /// <summary>The browser's download list.</summary>
    [JsAccessPath("downloads")]
    [JsonPropertyName("downloads")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Downloads { get; set; }

    /// <summary>The browser's stored form data.</summary>
    [JsAccessPath("formData")]
    [JsonPropertyName("formData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FormData { get; set; }

    /// <summary>The browser's history.</summary>
    [JsAccessPath("history")]
    [JsonPropertyName("history")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? History { get; set; }

    /// <summary>Websites' IndexedDB data.</summary>
    [JsAccessPath("indexedDB")]
    [JsonPropertyName("indexedDB")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IndexedDB { get; set; }

    /// <summary>Websites' local storage data.</summary>
    [JsAccessPath("localStorage")]
    [JsonPropertyName("localStorage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LocalStorage { get; set; }

    /// <summary>Stored passwords.</summary>
    [JsAccessPath("passwords")]
    [JsonPropertyName("passwords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Passwords { get; set; }

    /// <summary>Plugins' data.</summary>
    [JsAccessPath("pluginData")]
    [JsonPropertyName("pluginData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PluginData { get; set; }

    /// <summary>Server-bound certificates.</summary>
    [JsAccessPath("serverBoundCertificates")]
    [JsonPropertyName("serverBoundCertificates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ServerBoundCertificates { get; set; }

    /// <summary>Service Workers.</summary>
    [JsAccessPath("serviceWorkers")]
    [JsonPropertyName("serviceWorkers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ServiceWorkers { get; set; }
}
