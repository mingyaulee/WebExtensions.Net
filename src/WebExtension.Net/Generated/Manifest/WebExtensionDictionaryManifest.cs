using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Represents a WebExtension dictionary manifest.json file
    /// </summary>
    public class WebExtensionDictionaryManifest : BaseObject
    {
        
        // Property Definition
        private string _homepage_url;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _dictionaries;
        /// <summary>
        /// 
        /// </summary>
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

