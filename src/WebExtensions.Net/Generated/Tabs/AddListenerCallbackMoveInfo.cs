using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddListenerCallbackMoveInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("fromIndex")]
        public int FromIndex { get; set; }

        /// <summary></summary>
        [JsonPropertyName("toIndex")]
        public int ToIndex { get; set; }

        /// <summary></summary>
        [JsonPropertyName("windowId")]
        public int WindowId { get; set; }
    }
}
