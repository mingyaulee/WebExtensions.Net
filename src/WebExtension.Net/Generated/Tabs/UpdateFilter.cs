// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Class Definition
    /// <summary>
    /// An object describing filters to apply to tabs.onUpdated events.
    /// </summary>
    public class UpdateFilter
    {
        
        // Property Definition
        /// <summary>
        /// A list of URLs or URL patterns. Events that cannot match any of the URLs will be filtered out.  Filtering with urls requires the <c>"tabs"</c> or  <c>"activeTab"</c> permission.
        /// </summary>
        [JsonPropertyName("urls")]
        public IEnumerable<string> Urls { get; set; }
        
        // Property Definition
        /// <summary>
        /// A list of property names. Events that do not match any of the names will be filtered out.
        /// </summary>
        [JsonPropertyName("properties")]
        public IEnumerable<UpdatePropertyName> Properties { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tabId")]
        public int? TabId { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("windowId")]
        public int? WindowId { get; set; }
    }
}

