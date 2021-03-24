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
    /// Contents of manifest.json for a static theme
    /// </summary>
    public class ThemeManifest
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("theme")]
        public ThemeType Theme { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("dark_theme")]
        public ThemeType Dark_theme { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("default_locale")]
        public string Default_locale { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("theme_experiment")]
        public ThemeExperiment Theme_experiment { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("icons")]
        public object Icons { get; set; }
    }
}

