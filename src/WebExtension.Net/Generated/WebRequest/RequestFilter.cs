// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// An object describing filters to apply to webRequest events.
    /// </summary>
    public class RequestFilter
    {
        
        // Property Definition
        /// <summary>
        /// A list of URLs or URL patterns. Requests that cannot match any of the URLs will be filtered out.
        /// </summary>
        [JsonPropertyName("urls")]
        public IEnumerable<string> Urls { get; set; }
        
        // Property Definition
        /// <summary>
        /// A list of request types. Requests that cannot match any of the types will be filtered out.
        /// </summary>
        [JsonPropertyName("types")]
        public IEnumerable<ResourceType> Types { get; set; }
        
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
        
        // Property Definition
        /// <summary>
        /// If provided, requests that do not match the incognito state will be filtered out.
        /// </summary>
        [JsonPropertyName("incognito")]
        public bool? Incognito { get; set; }
    }
}

