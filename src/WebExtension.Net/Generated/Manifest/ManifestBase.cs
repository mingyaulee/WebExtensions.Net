using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Common properties for all manifest.json files
    /// </summary>
    public class ManifestBase : BaseObject
    {
        
        // Property Definition
        private int _manifest_version;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _applications;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private object _browser_specific_settings;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _name;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _short_name;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _description;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _author;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _version;
        /// <summary>
        /// 
        /// </summary>
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
    }
}

