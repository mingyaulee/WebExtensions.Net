// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Class Definition
    /// <summary>
    /// An object containing information about the current browser.
    /// </summary>
    public class BrowserInfo
    {
        
        // Property Definition
        /// <summary>
        /// The name of the browser, for example 'Firefox'.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        // Property Definition
        /// <summary>
        /// The name of the browser vendor, for example 'Mozilla'.
        /// </summary>
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }
        
        // Property Definition
        /// <summary>
        /// The browser's version, for example '42.0.0' or '0.8.1pre'.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
        
        // Property Definition
        /// <summary>
        /// The browser's build ID/date, for example '20160101'.
        /// </summary>
        [JsonPropertyName("buildID")]
        public string BuildID { get; set; }
    }
}

