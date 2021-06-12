using System.Text.Json.Serialization;

namespace WebExtensions.Net.BrowsingData
{
    // Type Class
    /// <summary>A set of data types. Missing data types are interpreted as <c>false</c>.</summary>
    public partial class DataTypeSet : BaseObject
    {
        private bool? _cache;
        private bool? _cookies;
        private bool? _downloads;
        private bool? _formData;
        private bool? _history;
        private bool? _indexedDB;
        private bool? _localStorage;
        private bool? _passwords;
        private bool? _pluginData;
        private bool? _serverBoundCertificates;
        private bool? _serviceWorkers;

        /// <summary>The browser's cache. Note: when removing data, this clears the <em>entire</em> cache: it is not limited to the range you specify.</summary>
        [JsonPropertyName("cache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cache
        {
            get
            {
                InitializeProperty("cache", _cache);
                return _cache;
            }
            set
            {
                _cache = value;
            }
        }

        /// <summary>The browser's cookies.</summary>
        [JsonPropertyName("cookies")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Cookies
        {
            get
            {
                InitializeProperty("cookies", _cookies);
                return _cookies;
            }
            set
            {
                _cookies = value;
            }
        }

        /// <summary>The browser's download list.</summary>
        [JsonPropertyName("downloads")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Downloads
        {
            get
            {
                InitializeProperty("downloads", _downloads);
                return _downloads;
            }
            set
            {
                _downloads = value;
            }
        }

        /// <summary>The browser's stored form data.</summary>
        [JsonPropertyName("formData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FormData
        {
            get
            {
                InitializeProperty("formData", _formData);
                return _formData;
            }
            set
            {
                _formData = value;
            }
        }

        /// <summary>The browser's history.</summary>
        [JsonPropertyName("history")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? History
        {
            get
            {
                InitializeProperty("history", _history);
                return _history;
            }
            set
            {
                _history = value;
            }
        }

        /// <summary>Websites' IndexedDB data.</summary>
        [JsonPropertyName("indexedDB")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IndexedDB
        {
            get
            {
                InitializeProperty("indexedDB", _indexedDB);
                return _indexedDB;
            }
            set
            {
                _indexedDB = value;
            }
        }

        /// <summary>Websites' local storage data.</summary>
        [JsonPropertyName("localStorage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LocalStorage
        {
            get
            {
                InitializeProperty("localStorage", _localStorage);
                return _localStorage;
            }
            set
            {
                _localStorage = value;
            }
        }

        /// <summary>Stored passwords.</summary>
        [JsonPropertyName("passwords")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Passwords
        {
            get
            {
                InitializeProperty("passwords", _passwords);
                return _passwords;
            }
            set
            {
                _passwords = value;
            }
        }

        /// <summary>Plugins' data.</summary>
        [JsonPropertyName("pluginData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PluginData
        {
            get
            {
                InitializeProperty("pluginData", _pluginData);
                return _pluginData;
            }
            set
            {
                _pluginData = value;
            }
        }

        /// <summary>Server-bound certificates.</summary>
        [JsonPropertyName("serverBoundCertificates")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ServerBoundCertificates
        {
            get
            {
                InitializeProperty("serverBoundCertificates", _serverBoundCertificates);
                return _serverBoundCertificates;
            }
            set
            {
                _serverBoundCertificates = value;
            }
        }

        /// <summary>Service Workers.</summary>
        [JsonPropertyName("serviceWorkers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ServiceWorkers
        {
            get
            {
                InitializeProperty("serviceWorkers", _serviceWorkers);
                return _serviceWorkers;
            }
            set
            {
                _serviceWorkers = value;
            }
        }
    }
}
