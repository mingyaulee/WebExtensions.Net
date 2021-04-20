using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Common properties for all manifest.json files</summary>
    public class ManifestBase : BaseObject
    {
        private object _applications;
        private string _author;
        private object _browser_specific_settings;
        private string _description;
        private string _homepage_url;
        private int _manifest_version;
        private string _name;
        private string _short_name;
        private string _version;

        /// <summary></summary>
        [JsonPropertyName("applications")]
        public object Applications
        {
            get
            {
                InitializeProperty("applications", _applications);
                return _applications;
            }
            set
            {
                _applications = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("author")]
        public string Author
        {
            get
            {
                InitializeProperty("author", _author);
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("browser_specific_settings")]
        public object Browser_specific_settings
        {
            get
            {
                InitializeProperty("browser_specific_settings", _browser_specific_settings);
                return _browser_specific_settings;
            }
            set
            {
                _browser_specific_settings = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("description")]
        public string Description
        {
            get
            {
                InitializeProperty("description", _description);
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("homepage_url")]
        public string Homepage_url
        {
            get
            {
                InitializeProperty("homepage_url", _homepage_url);
                return _homepage_url;
            }
            set
            {
                _homepage_url = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("manifest_version")]
        public int Manifest_version
        {
            get
            {
                InitializeProperty("manifest_version", _manifest_version);
                return _manifest_version;
            }
            set
            {
                _manifest_version = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("short_name")]
        public string Short_name
        {
            get
            {
                InitializeProperty("short_name", _short_name);
                return _short_name;
            }
            set
            {
                _short_name = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("version")]
        public string Version
        {
            get
            {
                InitializeProperty("version", _version);
                return _version;
            }
            set
            {
                _version = value;
            }
        }
    }
}
