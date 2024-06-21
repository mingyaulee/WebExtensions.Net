using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Runtime
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class ConnectInfo : BaseObject
    {
        /// <summary>Whether the TLS channel ID will be passed into onConnectExternal for processes that are listening for the connection event.</summary>
        [JsAccessPath("includeTlsChannelId")]
        [JsonPropertyName("includeTlsChannelId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeTlsChannelId { get; set; }

        /// <summary>Will be passed into onConnect for processes that are listening for the connection event.</summary>
        [JsAccessPath("name")]
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
    }
}
