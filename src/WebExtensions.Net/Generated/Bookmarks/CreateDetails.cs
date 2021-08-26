using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary>Object passed to the create() function.</summary>
    [BindAllProperties]
    public partial class CreateDetails : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary>Defaults to the Other Bookmarks folder.</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId { get; set; }

        /// <summary></summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>Indicates the type of BookmarkTreeNode to create, which can be one of bookmark, folder or separator.</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BookmarkTreeNodeType? Type { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
