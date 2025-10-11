using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History;

// Type Class
/// <summary>An object encapsulating one result of a history query.</summary>
[BindAllProperties]
public partial class HistoryItem : BaseObject
{
    /// <summary>The unique identifier for the item.</summary>
    [JsAccessPath("id")]
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Id { get; set; }

    /// <summary>When this page was last loaded, represented in milliseconds since the epoch.</summary>
    [JsAccessPath("lastVisitTime")]
    [JsonPropertyName("lastVisitTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EpochTime? LastVisitTime { get; set; }

    /// <summary>The title of the page when it was last loaded.</summary>
    [JsAccessPath("title")]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    /// <summary>The number of times the user has navigated to this page by typing in the address.</summary>
    [JsAccessPath("typedCount")]
    [JsonPropertyName("typedCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TypedCount { get; set; }

    /// <summary>The URL navigated to by a user.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }

    /// <summary>The number of times the user has navigated to this page.</summary>
    [JsAccessPath("visitCount")]
    [JsonPropertyName("visitCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? VisitCount { get; set; }
}
