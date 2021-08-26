using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class AddListenerCallbackAttachInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("newPosition")]
        public int NewPosition { get; set; }

        /// <summary></summary>
        [JsonPropertyName("newWindowId")]
        public int NewWindowId { get; set; }
    }
}
