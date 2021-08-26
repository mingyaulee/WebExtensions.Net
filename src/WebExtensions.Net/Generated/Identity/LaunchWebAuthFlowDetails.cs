using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Identity
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class LaunchWebAuthFlowDetails : BaseObject
    {
        /// <summary></summary>
        [JsonPropertyName("interactive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Interactive { get; set; }

        /// <summary></summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpURL Url { get; set; }
    }
}
