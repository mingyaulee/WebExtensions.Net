using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.History;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class Query : BaseObject
{
    /// <summary>Limit results to those visited before this date.</summary>
    [JsAccessPath("endTime")]
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Date EndTime { get; set; }

    /// <summary>The maximum number of results to retrieve.  Defaults to 100.</summary>
    [JsAccessPath("maxResults")]
    [JsonPropertyName("maxResults")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxResults { get; set; }

    /// <summary>Limit results to those visited after this date. If not specified, this defaults to 24 hours in the past.</summary>
    [JsAccessPath("startTime")]
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Date StartTime { get; set; }

    /// <summary>A free-text query to the history service.  Leave empty to retrieve all pages.</summary>
    [JsAccessPath("text")]
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Text { get; set; }
}
