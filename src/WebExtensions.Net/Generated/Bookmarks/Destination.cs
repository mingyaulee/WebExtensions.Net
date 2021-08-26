using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Destination : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary></summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId { get; set; }
    }
}
