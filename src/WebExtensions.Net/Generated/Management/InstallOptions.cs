using JsBind.Net;
using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class InstallOptions : BaseObject
    {
        /// <summary>A hash of the XPI file, using sha256 or stronger.</summary>
        [JsonPropertyName("hash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Hash { get; set; }

        /// <summary>URL pointing to the XPI file on addons.mozilla.org or similar.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpURL Url { get; set; }
    }
}
