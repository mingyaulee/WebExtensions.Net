using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Bookmarks
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class HasListenerCallbackMoveInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary></summary>
        [JsonPropertyName("oldIndex")]
        public int OldIndex { get; set; }

        /// <summary></summary>
        [JsonPropertyName("oldParentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OldParentId { get; set; }

        /// <summary></summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ParentId { get; set; }
    }
}
