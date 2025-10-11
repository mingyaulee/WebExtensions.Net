using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class GetVisitsDetails : BaseObject
{
    /// <summary>The URL for which to retrieve visit information.  It must be in the format as returned from a call to history.search.</summary>
    [JsAccessPath("url")]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Url { get; set; }
}
