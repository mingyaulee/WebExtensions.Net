using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AttachInfo : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("newPosition")]
        [JsonPropertyName("newPosition")]
        public int NewPosition { get; set; }

        /// <summary></summary>
        [JsAccessPath("newWindowId")]
        [JsonPropertyName("newWindowId")]
        public int NewWindowId { get; set; }
    }
}
