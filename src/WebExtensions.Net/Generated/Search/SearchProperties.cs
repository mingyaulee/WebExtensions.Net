using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class SearchProperties : BaseObject
{
    /// <summary>Location where search results should be displayed. NEW_TAB is the default.</summary>
    [JsAccessPath("disposition")]
    [JsonPropertyName("disposition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Disposition? Disposition { get; set; }

    /// <summary>Search engine to use. Uses the default if not specified.</summary>
    [JsAccessPath("engine")]
    [JsonPropertyName("engine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Engine { get; set; }

    /// <summary>Terms to search for.</summary>
    [JsAccessPath("query")]
    [JsonPropertyName("query")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Query { get; set; }

    /// <summary>The ID of the tab for the search results. If not specified, a new tab is created, unless disposition is set. tabId cannot be used with disposition.</summary>
    [JsAccessPath("tabId")]
    [JsonPropertyName("tabId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TabId { get; set; }
}
