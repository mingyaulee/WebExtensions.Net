using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class ChangeInfo : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    /// <summary></summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
