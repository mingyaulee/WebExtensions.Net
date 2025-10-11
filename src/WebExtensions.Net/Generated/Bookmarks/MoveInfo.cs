using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class MoveInfo : BaseObject
{
    /// <summary></summary>
    [JsAccessPath("index")]
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary></summary>
    [JsAccessPath("oldIndex")]
    [JsonPropertyName("oldIndex")]
    public int OldIndex { get; set; }

    /// <summary></summary>
    [JsAccessPath("oldParentId")]
    [JsonPropertyName("oldParentId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string OldParentId { get; set; }

    /// <summary></summary>
    [JsAccessPath("parentId")]
    [JsonPropertyName("parentId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ParentId { get; set; }
}
