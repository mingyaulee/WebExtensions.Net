// This file is auto generated at 2021-03-24T04:51:22

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
    public class ManifestBase
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("manifest_version")]
        public int Manifest_version { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("applications")]
        public object Applications { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("browser_specific_settings")]
        public object Browser_specific_settings { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("short_name")]
        public string Short_name { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("homepage_url")]
        public string Homepage_url { get; set; }
    }
}

