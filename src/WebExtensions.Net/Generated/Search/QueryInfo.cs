using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class QueryInfo : BaseObject
    {
        /// <summary>Location where search results should be displayed. CURRENT_TAB is the default.</summary>
        [JsonPropertyName("disposition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Disposition? Disposition { get; set; }

        /// <summary>Location where search results should be displayed. tabId cannot be used with disposition.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }

        /// <summary>String to query with the default search provider.</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Text { get; set; }
    }
}
