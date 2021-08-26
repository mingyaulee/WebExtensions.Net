using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RemoveListenerCallbackChangeInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
