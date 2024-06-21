using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary>A node (either a bookmark or a folder) in the bookmark tree.  Child nodes are ordered within their parent folder.</summary>
    [BindAllProperties]
    public partial class BookmarkTreeNode : BaseObject
    {
        /// <summary>An ordered list of children of this node.</summary>
        [JsAccessPath("children")]
        [JsonPropertyName("children")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<BookmarkTreeNode> Children { get; set; }

        /// <summary>When this node was created, in milliseconds since the epoch (<c>new Date(dateAdded)</c>).</summary>
        [JsAccessPath("dateAdded")]
        [JsonPropertyName("dateAdded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochTime? DateAdded { get; set; }

        /// <summary>When the contents of this folder last changed, in milliseconds since the epoch.</summary>
        [JsAccessPath("dateGroupModified")]
        [JsonPropertyName("dateGroupModified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochTime? DateGroupModified { get; set; }

        /// <summary>The unique identifier for the node. IDs are unique within the current profile, and they remain valid even after the browser is restarted.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>The 0-based position of this node within its parent folder.</summary>
        [JsAccessPath("index")]
        [JsonPropertyName("index")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }

        /// <summary>The <c>id</c> of the parent folder.  Omitted for the root node.</summary>
        [JsAccessPath("parentId")]
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId { get; set; }

        /// <summary>The text displayed for the node.</summary>
        [JsAccessPath("title")]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        /// <summary>Indicates the type of the BookmarkTreeNode, which can be one of bookmark, folder or separator.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BookmarkTreeNodeType? Type { get; set; }

        /// <summary>Indicates the reason why this node is unmodifiable. The <c>managed</c> value indicates that this node was configured by the system administrator or by the custodian of a supervised user. Omitted if the node can be modified by the user and the extension (default).</summary>
        [JsAccessPath("unmodifiable")]
        [JsonPropertyName("unmodifiable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BookmarkTreeNodeUnmodifiable? Unmodifiable { get; set; }

        /// <summary>The URL navigated to when a user clicks the bookmark. Omitted for folders.</summary>
        [JsAccessPath("url")]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
    }
}
