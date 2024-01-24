using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class DetachInfo : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("oldPosition")]
        public int OldPosition { get; set; }

        /// <summary></summary>
        [JsonPropertyName("oldWindowId")]
        public int OldWindowId { get; set; }
    }
}
