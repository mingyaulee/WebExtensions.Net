using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class RemoveListenerCallbackDetachInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("oldPosition")]
        public int OldPosition { get; set; }

        /// <summary></summary>
        [JsonPropertyName("oldWindowId")]
        public int OldWindowId { get; set; }
    }
}
