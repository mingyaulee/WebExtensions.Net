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
    public class ThemeIcons
    {
        
        /// Property Definition
        /// <summary>A light icon to use for dark themes</summary>
        [JsonPropertyName("light")]
        public ExtensionURL Light { get; set; }
        
        /// Property Definition
        /// <summary>The dark icon to use for light themes</summary>
        [JsonPropertyName("dark")]
        public ExtensionURL Dark { get; set; }
        
        /// Property Definition
        /// <summary>The size of the icons</summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}

