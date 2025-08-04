using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.TabGroups
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class MoveProperties : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("index")]
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary></summary>
        [JsAccessPath("windowId")]
        [JsonPropertyName("windowId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? WindowId { get; set; }
    }
}
