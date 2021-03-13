/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    /// Class Definition
    /// <summary>Represents a WebExtension language pack manifest.json file</summary>
    public class WebExtensionLangpackManifest
    {
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("homepage_url")]
        public string Homepage_url { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("langpack_id")]
        public string Langpack_id { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("languages")]
        public object Languages { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("sources")]
        public object Sources { get; set; }
    }
}

