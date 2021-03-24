// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    // Class Definition
    /// <summary>
    /// 
    /// </summary>
    public class EventUrlFilters
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("url")]
        public IEnumerable<Events.UrlFilter> Url { get; set; }
    }
}

