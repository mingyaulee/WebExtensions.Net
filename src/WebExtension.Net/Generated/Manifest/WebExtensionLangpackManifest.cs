using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Represents a WebExtension language pack manifest.json file
    /// </summary>
    public class WebExtensionLangpackManifest : BaseObject
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
        private string _langpack_id;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("langpack_id")]
        public string Langpack_id
        {
            get
            {
                InitializeProperty("langpack_id", _langpack_id);
                return _langpack_id;
            }
            set
            {
                _langpack_id = value;
            }
        }
        
        // Property Definition
        private object _languages;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("languages")]
        public object Languages
        {
            get
            {
                InitializeProperty("languages", _languages);
                return _languages;
            }
            set
            {
                _languages = value;
            }
        }
        
        // Property Definition
        private object _sources;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sources")]
        public object Sources
        {
            get
            {
                InitializeProperty("sources", _sources);
                return _sources;
            }
            set
            {
                _sources = value;
            }
        }
    }
}

