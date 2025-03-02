using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.NetworkStatus
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class NetworkLinkInfo : BaseObject
    {
        /// <summary>If known, the network id or name.</summary>
        [JsAccessPath("id")]
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        /// <summary>Status of the network link, if "unknown" then link is usually assumed to be "up"</summary>
        [JsAccessPath("status")]
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>If known, the type of network connection that is avialable.</summary>
        [JsAccessPath("type")]
        [JsonPropertyName("type")]
        public NetworkLinkInfoType Type { get; set; }
    }
}
