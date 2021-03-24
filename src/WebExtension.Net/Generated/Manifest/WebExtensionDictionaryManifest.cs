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
    /// Represents a WebExtension dictionary manifest.json file
    /// </summary>
    public class WebExtensionDictionaryManifest
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("homepage_url")]
        public string Homepage_url { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("dictionaries")]
        public object Dictionaries { get; set; }
    }
}

