using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary></summary>
    public class FirefoxSpecificProperties : BaseObject
    {
        private ExtensionID _id;
        private string _update_url;
        private string _strict_min_version;
        private string _strict_max_version;

        /// <summary></summary>
        [JsonPropertyName("id")]
        public ExtensionID Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("update_url")]
        public string Update_url
        {
            get
            {
                InitializeProperty("update_url", _update_url);
                return _update_url;
            }
            set
            {
                _update_url = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("strict_min_version")]
        public string Strict_min_version
        {
            get
            {
                InitializeProperty("strict_min_version", _strict_min_version);
                return _strict_min_version;
            }
            set
            {
                _strict_min_version = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("strict_max_version")]
        public string Strict_max_version
        {
            get
            {
                InitializeProperty("strict_max_version", _strict_max_version);
                return _strict_max_version;
            }
            set
            {
                _strict_max_version = value;
            }
        }
    }
}
