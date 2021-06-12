using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    // Type Class
    /// <summary></summary>
    public partial class InstallOptions : BaseObject
    {
        private string _hash;
        private HttpURL _url;

        /// <summary>A hash of the XPI file, using sha256 or stronger.</summary>
        [JsonPropertyName("hash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Hash
        {
            get
            {
                InitializeProperty("hash", _hash);
                return _hash;
            }
            set
            {
                _hash = value;
            }
        }

        /// <summary>URL pointing to the XPI file on addons.mozilla.org or similar.</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HttpURL Url
        {
            get
            {
                InitializeProperty("url", _url);
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
