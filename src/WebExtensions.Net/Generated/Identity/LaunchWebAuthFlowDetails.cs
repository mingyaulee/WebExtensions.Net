using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Identity
{
    // Type Class
    /// <summary></summary>
    public partial class LaunchWebAuthFlowDetails : BaseObject
    {
        private bool? _interactive;
        private HttpURL _url;

        /// <summary></summary>
        [JsonPropertyName("interactive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Interactive
        {
            get
            {
                InitializeProperty("interactive", _interactive);
                return _interactive;
            }
            set
            {
                _interactive = value;
            }
        }

        /// <summary></summary>
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
