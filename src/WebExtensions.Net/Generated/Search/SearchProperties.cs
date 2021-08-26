using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class SearchProperties : BaseObject
    {
        /// <summary>Search engine to use. Uses the default if not specified.</summary>
        [JsonPropertyName("engine")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Engine { get; set; }

        /// <summary>Terms to search for.</summary>
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Query { get; set; }

        /// <summary>The ID of the tab for the search results. If not specified, a new tab is created.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
    }
}
