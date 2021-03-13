/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Class Definition
    /// <summary>Defines how zoom changes in a tab are handled and at what scope.</summary>
    public class ZoomSettings
    {
        
        /// Property Definition
        /// <summary>Defines how zoom changes are handled, i.e. which entity is responsible for the actual scaling of the page; defaults to <code>automatic</code>.</summary>
        [JsonPropertyName("mode")]
        public ZoomSettingsMode Mode { get; set; }
        
        /// Property Definition
        /// <summary>Defines whether zoom changes will persist for the page's origin, or only take effect in this tab; defaults to <code>per-origin</code> when in <code>automatic</code> mode, and <code>per-tab</code> otherwise.</summary>
        [JsonPropertyName("scope")]
        public ZoomSettingsScope Scope { get; set; }
        
        /// Property Definition
        /// <summary>Used to return the default zoom level for the current tab in calls to tabs.getZoomSettings.</summary>
        [JsonPropertyName("defaultZoomFactor")]
        public double? DefaultZoomFactor { get; set; }
    }
}

