using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Sessions
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Filter : BaseObject
    {
        /// <summary>The maximum number of entries to be fetched in the requested list. Omit this parameter to fetch the maximum number of entries ($(ref:sessions.MAX_SESSION_RESULTS)).</summary>
        [JsonPropertyName("maxResults")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxResults { get; set; }
    }
}
