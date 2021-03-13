/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// Class Definition
    /// <summary></summary>
    public class FirefoxSpecificProperties
    {
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("id")]
        public ExtensionID Id { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("update_url")]
        public string Update_url { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("strict_min_version")]
        public string Strict_min_version { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("strict_max_version")]
        public string Strict_max_version { get; set; }
    }
}

