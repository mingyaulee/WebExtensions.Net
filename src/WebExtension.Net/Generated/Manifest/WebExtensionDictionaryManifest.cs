using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Represents a WebExtension dictionary manifest.json file</summary>
    public class WebExtensionDictionaryManifest : BaseObject
    {
        private string _homepage_url;
        private object _dictionaries;

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
        [JsonPropertyName("dictionaries")]
        public object Dictionaries
        {
            get
            {
                InitializeProperty("dictionaries", _dictionaries);
                return _dictionaries;
            }
            set
            {
                _dictionaries = value;
            }
        }
    }
}
