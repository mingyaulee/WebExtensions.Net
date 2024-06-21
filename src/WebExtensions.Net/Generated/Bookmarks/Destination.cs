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
        [JsAccessPath("index")]
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary></summary>
        [JsAccessPath("parentId")]
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId { get; set; }
    }
}
