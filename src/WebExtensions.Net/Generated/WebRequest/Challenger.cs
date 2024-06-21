using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest
{
    // Type Class
    /// <summary>The server requesting authentication.</summary>
    [BindAllProperties]
    public partial class Challenger : BaseObject
    {
        /// <summary></summary>
        [JsAccessPath("host")]
        [JsonPropertyName("host")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Host { get; set; }

        /// <summary></summary>
        [JsAccessPath("port")]
        [JsonPropertyName("port")]
        public int Port { get; set; }
    }
}
