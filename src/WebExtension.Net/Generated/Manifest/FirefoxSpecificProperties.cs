using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class FirefoxSpecificProperties : BaseObject
    {
        
        // Property Definition
        private ExtensionID _id;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _update_url;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _strict_min_version;
        /// <summary>
        /// 
        /// </summary>
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
        
        // Property Definition
        private string _strict_max_version;
        /// <summary>
        /// 
        /// </summary>
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

