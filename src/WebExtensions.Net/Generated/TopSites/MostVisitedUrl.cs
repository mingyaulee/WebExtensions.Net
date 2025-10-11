using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites;

// Type Class
/// <summary>An object encapsulating a most visited URL, such as the URLs on the new tab page.</summary>
[BindAllProperties]
public partial class MostVisitedUrl : BaseObject
{
    /// <summary>Data URL for the favicon, if available.</summary>
    [JsAccessPath("favicon")]
    [JsonPropertyName("favicon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Favicon { get; set; }

    /// <summary>The title of the page.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    /// <summary>The entry type, either <c>url</c> for a normal page link, or <c>search</c> for a search shortcut.</summary>
    [JsAccessPath("type")]
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MostVisitedUrlType? Type { get; set; }

    /// <summary>The most visited URL.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
