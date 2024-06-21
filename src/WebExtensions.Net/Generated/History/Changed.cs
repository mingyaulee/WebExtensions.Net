using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.History
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Changed : BaseObject
    {
        /// <summary>The new title for the URL.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The URL for which the title has changed</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
