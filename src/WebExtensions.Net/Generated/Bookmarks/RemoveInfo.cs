using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class RemoveInfo : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("index")]
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary></summary>
    [JsAccessPath("node")]
    [JsonPropertyName("node")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BookmarkTreeNode Node { get; set; }

    /// <summary></summary>
    [JsAccessPath("parentId")]
    [JsonPropertyName("parentId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ParentId { get; set; }
}
