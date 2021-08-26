using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites
{
    // Type Class
    /// <summary>An object encapsulating a most visited URL, such as the URLs on the new tab page.</summary>
    [BindAllProperties]
    public partial class MostVisitedURL : BaseObject
    {
        /// <summary>Data URL for the favicon, if available.</summary>
        [JsonPropertyName("favicon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Favicon { get; set; }

        /// <summary>The title of the page.</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>The entry type, either <c>url</c> for a normal page link, or <c>search</c> for a search shortcut.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; }

        /// <summary>The most visited URL.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
